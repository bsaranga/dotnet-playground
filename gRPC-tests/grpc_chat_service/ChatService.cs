using Grpc.Core;

namespace grpc_chat_service
{
    class ChatService : Chat.ChatBase
    {
        public override async Task SendMessage(IAsyncStreamReader<MessageRequest> requestStream, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                // Process the incoming message
                Console.WriteLine($"Received message: {request.Content}");

                // Send a response
                await responseStream.WriteAsync(new MessageResponse { Content = $"Server received: {request.Content}" });
            }
        }
    }
}
