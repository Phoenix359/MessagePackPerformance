using MessagePack;
using System.IO;

namespace MessagePackV2
{
    public class MessagePackSerializerV2
    {
        public MessagePackSerializerV2(){ }

        public void Serialize(object instance, Stream destination)
        {
            MessagePackSerializer.Serialize(instance.GetType(), destination, instance);
        }

        public T Deserialize<T>(Stream source)
        {
            return MessagePackSerializer.Deserialize<T>(source);
        }
    }
}
