using VContainer;
using VContainer.Unity;
using MessagePipe;
using MessagePipe.Interprocess.Workers;
using MessagePack;
using MessagePack.Resolvers;

namespace MessagePipeDemo.InterprocessDemo
{
    public class ServerAppLifecycle : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe(/* configure option */);

            var serviceCollection = builder.AsServiceCollection(); // Require to convert ServiceCollection to enable Interprocess
            
            var interprocessOptions = serviceCollection.AddMessagePipeTcpInterprocess("127.0.0.1", 3215, tcpOptions =>
            {
                tcpOptions.MessagePackSerializerOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
            });
            
            // RemoteRequestHandler
            // serviceCollection.RegisterTcpRemoteRequestHandler<Request, Response>(interprocessOptions); // For client
            builder.RegisterAsyncRequestHandler<Request, Response, Server>(options); // For server
        }

        protected override void Awake()
        {
            base.Awake();
            
            var tcpWorker = Container.Resolve<TcpWorker>();
            tcpWorker.StartReceiver();
        }
    }
}
