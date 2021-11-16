namespace MessagePipeSamples.Filter
{
    public class Message
    {
        public MessageType Type;
        public string Text;
    }

    public enum MessageType
    {
        TypeA,
        TypeB,
        TypeC,
    }
}
