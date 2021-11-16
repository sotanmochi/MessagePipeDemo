using UnityEngine;
using MessagePipe;

namespace MessagePipeSamples.Filter
{
    [DefaultExecutionOrder(-2000)]
    public class MessagePipeBuilder : MonoBehaviour
    {
        private void Awake()
        {
            BuildMessagePipe();
        }

        private void BuildMessagePipe()
        {
            var builder = new BuiltinContainerBuilder();
            builder.AddMessagePipe();

            // Register for IPublisher<T>/ISubscriber<T>, includes async and buffered.
            builder.AddMessageBroker<Message>();

            var resolver = builder.BuildServiceProvider();
            GlobalMessagePipe.SetProvider(resolver);
        }
    }
}
