using System;
using MessagePipe;
using VContainer;

namespace MessagePipeSamples.Basic
{
    public class MessageSubscriberA : VContainer.Unity.IStartable, IDisposable
    {
        readonly ISubscriber<MessageKey, Message> _subscriber;
        IDisposable _disposable;

        public MessageSubscriberA(ISubscriber<MessageKey, Message> subscriber)
        {
            _subscriber = subscriber;
        }

        public void Start()
        {
            // UnityEngine.Debug.Log("Start@SubscriberA");

            var d = DisposableBag.CreateBuilder();
            _subscriber.Subscribe(MessageKey.TypeA, x => UnityEngine.Debug.Log(x.Data + "@SubscriberA")).AddTo(d);

            _disposable = d.Build();
        }

        public void Dispose()
        {
            // UnityEngine.Debug.Log("Dispose@SubscriberA");
            _disposable.Dispose();
        }
    }
}
