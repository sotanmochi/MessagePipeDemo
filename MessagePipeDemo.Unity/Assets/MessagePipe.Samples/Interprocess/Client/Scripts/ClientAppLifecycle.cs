using VContainer;
using VContainer.Unity;
using MessagePipe;
using MessagePack;
using MessagePack.Resolvers;

namespace MessagePipeDemo.InterprocessDemo
{
    public class ClientAppLifecycle : LifetimeScope
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
            serviceCollection.RegisterTcpRemoteRequestHandler<Request, Response>(interprocessOptions); // For client
            
            builder.RegisterComponentInHierarchy<InterprocessView>();
            builder.Register<InterprocessPresenter>(Lifetime.Singleton);
        }
        
        protected override void Awake()
        {
            base.Awake();
            
            var presenter = Container.Resolve<InterprocessPresenter>();
            presenter.Initialize();
        }
    }
}
