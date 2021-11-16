using MessagePack;

namespace MessagePipeSamples.Interprocess
{
    [MessagePackObject]
    public class Request
    {
        [Key(0)]
        public string Message;
    }
}