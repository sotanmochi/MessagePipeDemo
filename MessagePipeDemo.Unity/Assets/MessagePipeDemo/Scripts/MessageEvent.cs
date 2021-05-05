using System;
using MessagePipe;
using VContainer.Unity;

namespace MessagePipeDemo
{
    public class MessageEvent : ITickable, IFixedTickable, IDisposable
    {
        // using MessagePipe instead of C# event/Rx.Subject
        // store Publisher to private field(declare IDisposablePublisher/IDisposableAsyncPublisher)
        IDisposablePublisher<Message> _tickPublisher;

        // Subscriber is used from outside so public property
        public ISubscriber<Message> OnTick { get; }

        IDisposablePublisher<Message> _fixedTickPublisher;
        public ISubscriber<Message> OnFixedTick { get; }

        public MessageEvent(EventFactory eventFactory)
        {
            // CreateEvent can deconstruct by tuple and set together
            (_tickPublisher, OnTick) = eventFactory.CreateEvent<Message>();
            (_fixedTickPublisher, OnFixedTick) = eventFactory.CreateEvent<Message>();
        }

        int count;
        public void Tick()
        {
            count++;
            _tickPublisher.Publish(new Message(){ Data = "OnTick" });
            // UnityEngine.Debug.Log($"Tick(): {count} @MessageEvent");
        }

        public void FixedTick()
        {
            _fixedTickPublisher.Publish(new Message(){ Data = "OnFixedTick" });
        }

        public void Dispose()
        {
            // You can unsubscribe all from Publisher.
            _tickPublisher.Dispose();
            _fixedTickPublisher.Dispose();
        }
    }
}
