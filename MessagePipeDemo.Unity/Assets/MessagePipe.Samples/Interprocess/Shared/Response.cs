using MessagePack;

namespace MessagePipeSamples.Interprocess
{
    [MessagePackObject]
    public class Response
    {
        [Key(0)]
        public int Code;
        [Key(1)]
        public string Message;
    }
}