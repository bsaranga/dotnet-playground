using NetMQ;
using NetMQ.Sockets;

namespace ZMQClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");
                while (true)
                {
                    Console.Write("Enter message: ");
                    string message = Console.ReadLine() ?? "<empty_message>";
                    if (message == "exit" || message == "x")
                        break;
                    else if (message.StartsWith("loop_"))
                    {
                        message = message.Split('_')[1];
                        while (true)
                        {
                            Console.Write(message);
                            client.SendFrame(message);
                            var response = client.ReceiveFrameString();
                            Console.Write($" ");
                        }
                    }
                    else
                    {
                        client.SendFrame(message);
                        var response = client.ReceiveFrameString();
                        Console.WriteLine($"Received response from server:\n{response}");
                    }
                }
            }

            Console.WriteLine("Client ended");
        }
    }
}