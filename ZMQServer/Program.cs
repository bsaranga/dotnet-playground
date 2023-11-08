using NetMQ;
using NetMQ.Sockets;

namespace ZMQServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");
                Console.WriteLine("Listening on port 5555...");
                while (true)
                {
                    var message = server.ReceiveFrameString();
                    Console.WriteLine($"Received: {message}");
                    server.SendFrame($"Ack: {message}");
                }
            }
        }
    }
}