using MessagePack;
using System.IO;

namespace MessagePackV1
{
    public class MessagePackSerializerV1
    {
        public MessagePackSerializerV1() { }

        public void Serialize(object instance, Stream destination)
        {
            MessagePackSerializer.NonGeneric.Serialize(instance.GetType(), destination, instance);
        }

        public T Deserialize<T>(Stream source)
        {
            return MessagePackSerializer.Deserialize<T>(source);
        }
    }
}
