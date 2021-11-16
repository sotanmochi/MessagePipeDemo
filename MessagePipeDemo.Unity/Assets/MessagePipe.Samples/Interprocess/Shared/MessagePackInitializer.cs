using UnityEngine;
using MessagePack;
using MessagePack.Resolvers;

namespace MessagePipeDemo.InterprocessDemo
{
    public class MessagePackInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void InitializeOnBeforeSceneLoad()
        {
            Debug.Log("<color=orange> MessagePackInitializer.Initialize() </color>");

            StaticCompositeResolver.Instance.Register
            (
                GeneratedResolver.Instance,
                StandardResolver.Instance
            );

            // MessagePackSerializer.DefaultOptions = 
            //     MessagePackSerializerOptions.Standard
            //     .WithResolver(StaticCompositeResolver.Instance);
        }
    }
}