using MessagePack;

namespace MessagePipeDemo.InterprocessDemo
{
    [MessagePackObject]
    public class Request
    {
        [Key(0)]
        public string Message;
    }
}