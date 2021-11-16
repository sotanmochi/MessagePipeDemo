using System;
using MessagePipe;

namespace MessagePipeSamples.Filter
{
    public class MessageTypeFilter : MessageHandlerFilter<Message>
    {
        private MessageType _type;

        public MessageTypeFilter(MessageType type)
        {
            _type = type;
        }

        public override void Handle(Message message, Action<Message> next)
        {
            if (message.Type == _type)
            {
                next(message);
            }
        }
    }
}
