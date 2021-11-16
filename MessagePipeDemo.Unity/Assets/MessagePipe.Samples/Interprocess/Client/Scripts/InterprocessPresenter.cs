using MessagePipe;
using Cysharp.Threading.Tasks;

namespace MessagePipeDemo.InterprocessDemo
{
    public class InterprocessPresenter
    {
        readonly InterprocessView _view;
        readonly IRemoteRequestHandler<Request, Response> _requestHandler;

        public InterprocessPresenter
        (
            InterprocessView view, 
            IRemoteRequestHandler<Request, Response> requestHandler
        )
        {
            _view = view;
            _requestHandler = requestHandler;
        }

        public void Initialize()
        {
            _view.OnSendMessage.Subscribe(message => 
                UniTask.Void(async() =>
                {
                    Response response = await _requestHandler.InvokeAsync(new Request() { Message = message });

                    // int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

                    await UniTask.SwitchToMainThread();
                    _view.SetMessageText(response.Message);
                }));
        }
    }
}
