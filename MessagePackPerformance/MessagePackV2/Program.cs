using MessagePack.Resolvers;
using System.Collections.Generic;

namespace MessagePackV2
{
    class Program
    {
        static void Main(string[] args)
        {
            StaticCompositeResolver.Instance.Register
            (
                NativeGuidResolver.Instance,
                NativeDecimalResolver.Instance,
                StandardResolver.Instance
            );

            MessagePack.MessagePackSerializer.DefaultOptions = MessagePack.MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);

            var dataList = FileReader.GetObjectFromBinaryFile<List<Data>>("TestSet");
            FileWriter.SaveDataAsBinaryFile(dataList, "TestSet_V2_output");
        }
    }
}
