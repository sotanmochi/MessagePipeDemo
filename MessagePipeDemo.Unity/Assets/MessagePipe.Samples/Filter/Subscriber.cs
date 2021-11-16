
using UnityEngine;
using MessagePipe;

namespace MessagePipeSamples.Filter
{
    public class Subscriber : MonoBehaviour
    {
        ISubscriber<Message> _subscriber;

        private void Awake()
        {
            _subscriber = GlobalMessagePipe.GetSubscriber<Message>();

            _subscriber.Subscribe(message => 
            {
                Debug.Log($"[Non filter] Type: \"{message.Type}\", Text: \"{message.Text}\"");
            });

            _subscriber.Subscribe(message => 
            {
                Debug.Log($"[Only TypeA] Type: \"{message.Type}\", Text: \"{message.Text}\"");
            },
            new MessageTypeFilter(MessageType.TypeA));

            _subscriber.Subscribe(message => 
            {
                Debug.Log($"[Only TypeC] Type: \"{message.Type}\", Text: \"{message.Text}\"");
            }, 
            new MessageTypeFilter(MessageType.TypeC));
        }
    }
}
