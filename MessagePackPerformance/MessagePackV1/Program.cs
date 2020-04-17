using System.Collections.Generic;

namespace MessagePackV1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataList = FileReader.GetObjectFromBinaryFile<List<Data>>("TestSet");
            FileWriter.SaveDataAsBinaryFile(dataList, "TestSet_V1_output");

            dataList = FileReader.GetObjectFromBinaryFile<List<Data>>("TestSet");
            FileWriter.SaveDataAsBinaryFile(dataList, "TestSet_V1_output");
        }
    }
}
