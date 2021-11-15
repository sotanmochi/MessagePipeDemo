using System;
using MessagePipe;
using VContainer;

namespace MessagePipeSamples.Basic
{
    public class MessagePublisher : VContainer.Unity.IStartable, IDisposable
    {
        readonly IPublisher<Message> _keylessPublisher;
        readonly ISubscriber<Message> _keylessSubscriber;
        readonly IPublisher<MessageKey, Message> _keyedPublisher;
        readonly ISubscriber<MessageKey, Message> _keyedSubscriber;
        IDisposable _disposable;

        public MessagePublisher(IPublisher<Message> keylessPublisher, ISubscriber<Message> keylessSubscriber, 
            IPublisher<MessageKey, Message> keyedPublisher, ISubscriber<MessageKey, Message> keyedSubscriber)
        {
            _keylessPublisher = keylessPublisher;
            _keylessSubscriber = keylessSubscriber;
            _keyedPublisher = keyedPublisher;
            _keyedSubscriber = keyedSubscriber;
        }

        public void Start()
        {
            // UnityEngine.Debug.Log("Start@Publisher");
            var d = DisposableBag.CreateBuilder();

            _keylessSubscriber.Subscribe(x =>
            {
                UnityEngine.Debug.Log(x.Data + "@Publisher");
            })
            .AddTo(d);

            _keylessPublisher.Publish(new Message(){ Data = "First message"});
            _keylessPublisher.Publish(new Message(){ Data = "Second message"});
            _keylessPublisher.Publish(new Message(){ Data = "Third message"});

            _keyedSubscriber.Subscribe(MessageKey.TypeC, x => 
            {
                UnityEngine.Debug.Log(x.Data + "@Publisher");
            })
            .AddTo(d);

            _keyedPublisher.Publish(MessageKey.TypeA, new Message(){ Data = "1st message"});
            _keyedPublisher.Publish(MessageKey.TypeB, new Message(){ Data = "2nd message"});
            _keyedPublisher.Publish(MessageKey.TypeC, new Message(){ Data = "3rd message"});
            
            _disposable = d.Build();
        }

        public void Dispose()
        {
            // UnityEngine.Debug.Log("Dispose@Publisher");
            _disposable.Dispose();
        }
    }
}
