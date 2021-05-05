using System;
using MessagePipe;
using VContainer;

namespace MessagePipeDemo
{
    public class MessageEventSubscriber : VContainer.Unity.IStartable, IDisposable
    {
        MessageEvent _messageEvent;
        IDisposable _disposable;

        public MessageEventSubscriber(MessageEvent messageEvent)
        {
            _messageEvent = messageEvent;
        }

        public void Start()
        {
            // UnityEngine.Debug.Log("Start@EventSubscriber");
            var d = DisposableBag.CreateBuilder();

            _messageEvent.OnTick.Subscribe(message => 
            {
                UnityEngine.Debug.Log(message.Data +  "@EventSubscriber");
            })
            .AddTo(d);

            _messageEvent.OnFixedTick.Subscribe(message => 
            {
                UnityEngine.Debug.Log(message.Data +  "@EventSubscriber");
            })
            .AddTo(d);

            _disposable = d.Build();
        }

        public void Dispose()
        {
            // UnityEngine.Debug.Log("Dispose@EventSubscriber");
            _disposable.Dispose();
        }
    }
}
