using System;
using MessagePipe;
using VContainer;

namespace MessagePipeSamples.Basic
{
    public class MessageSubscriberB : VContainer.Unity.IStartable, IDisposable
    {
        readonly ISubscriber<MessageKey, Message> _subscriber;
        IDisposable _disposable;

        public MessageSubscriberB(ISubscriber<MessageKey, Message> subscriber)
        {
            _subscriber = subscriber;
        }

        public void Start()
        {
            // UnityEngine.Debug.Log("Start@SubscriberB");

            var d = DisposableBag.CreateBuilder();
            _subscriber.Subscribe(MessageKey.TypeB, x => UnityEngine.Debug.Log(x.Data + "@SubscriberB")).AddTo(d);

            _disposable = d.Build();
        }

        public void Dispose()
        {
            // UnityEngine.Debug.Log("Dispose@SubscriberB");
            _disposable.Dispose();
        }
    }
}
