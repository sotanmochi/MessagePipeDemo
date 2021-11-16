using UnityEngine;
using MessagePipe;

namespace MessagePipeSamples.Filter
{
    public class Publisher : MonoBehaviour
    {
        IPublisher<Message> _publisher;

        private void Awake()
        {
            _publisher = GlobalMessagePipe.GetPublisher<Message>();
        }

        private void Start()
        {
            _publisher.Publish(new Message()
            {
                Type = MessageType.TypeA,
                Text = "Message A",
            });

            _publisher.Publish(new Message()
            {
                Type = MessageType.TypeB,
                Text = "Message B",
            });

            _publisher.Publish(new Message()
            {
                Type = MessageType.TypeC,
                Text = "Message C",
            });
        }
    }
}
