using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe;

namespace MessagePipeDemo.InterprocessDemo
{
    public class Server : IAsyncRequestHandler<Request, Response>
    {
        public async UniTask<Response> InvokeAsync(Request request, CancellationToken cancellationToken = default)
        {
            UnityEngine.Debug.Log("RequestMessage: " + request.Message);
            string message = "*** Echo: " + request.Message + " ***";
            return new Response(){ Message = message };
        }
    }
}