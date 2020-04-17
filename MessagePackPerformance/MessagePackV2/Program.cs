using MessagePack;
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
                NativeDateTimeResolver.Instance,                
                NativeGuidResolver.Instance,
                NativeDecimalResolver.Instance,
                TypelessObjectResolver.Instance,
                ContractlessStandardResolver.Instance
            );
            MessagePackSerializer.DefaultOptions = MessagePackSerializerOptions.Standard
                .WithResolver(StaticCompositeResolver.Instance)
                .WithCompression(MessagePackCompression.Lz4BlockArray);

            var dataList = FileReader.GetObjectFromBinaryFile<List<Data>>("TestSet");
            FileWriter.SaveDataAsBinaryFile(dataList, "TestSet_V2_output");

            dataList = FileReader.GetObjectFromBinaryFile<List<Data>>("TestSet");
            FileWriter.SaveDataAsBinaryFile(dataList, "TestSet_V2_output");
        }
    }
}
