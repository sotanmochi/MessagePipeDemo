using MessagePack;

namespace MessagePipeDemo.InterprocessDemo
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