# MessagePipeDemo

## MessagePipeDemo.unity

```cs
using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace MessagePipeDemo
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe(/* configure option */);

            builder.RegisterMessageBroker<Message>(options);
            builder.RegisterMessageBroker<MessageKey, Message>(options);

            builder.RegisterEntryPoint<MessageEvent>(Lifetime.Singleton).AsSelf();
            builder.RegisterEntryPoint<MessageEventSubscriber>(Lifetime.Singleton);

            builder.RegisterEntryPoint<MessageSubscriberA>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MessageSubscriberB>(Lifetime.Singleton);
            builder.RegisterEntryPoint<MessagePublisher>(Lifetime.Singleton);
        }
    }
}
```

<img src="./../../Docs/MessagePipeDemo.png">

## License
このプロジェクトは、サードパーティのアセットを除き、[CC0](http://creativecommons.org/publicdomain/zero/1.0/deed.ja) (Public Domain) でライセンスされています。  
This project is licensed under [CC0](https://creativecommons.org/publicdomain/zero/1.0/deed.en) (Public Domain), except for third party assets.
