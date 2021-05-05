using System;
using MessagePipe;
using VContainer;

namespace MessagePipeDemo
{
    public class MessageEvent : VContainer.Unity.ITickable, IDisposable
    {
        // using MessagePipe instead of C# event/Rx.Subject
        // store Publisher to private field(declare IDisposablePublisher/IDisposableAsyncPublisher)
        IDisposablePublisher<Message> _tickPublisher;

        // Subscriber is used from outside so public property
        public ISubscriber<Message> OnTick { get; }

        public MessageEvent(EventFactory eventFactory)
        {
            // CreateEvent can deconstruct by tuple and set together
            (_tickPublisher, OnTick) = eventFactory.CreateEvent<Message>();
        }

        int count;
        public void Tick()
        {
            count++;
            _tickPublisher.Publish(new Message(){ Data = "OnTick" });
            // UnityEngine.Debug.Log($"Tick(): {count} @MessageEvent");
        }

        public void Dispose()
        {
            // You can unsubscribe all from Publisher.
            _tickPublisher.Dispose();
        }
    }
}
