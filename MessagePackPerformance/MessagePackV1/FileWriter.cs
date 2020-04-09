using System;
using System.IO;

namespace MessagePackV1
{
    public static class FileWriter
    {
        private static readonly string _baseResultPath = @"..\..\..\";

        public static void SaveDataAsBinaryFile(object data, string fileName)
        {
            if (!fileName.EndsWith(".bin"))
            {
                fileName += ".bin";
            }

            var fileLocation = Path.Combine(_baseResultPath, fileName);

            using (var stream = new MemoryStream())
            {
                var startTime = DateTime.Now;
                var serializer = new MessagePackSerializerV1();
                serializer.Serialize(data, stream);
                Console.WriteLine($" |--> MessagePack V1 serialize to stream time: {(DateTime.Now - startTime).ToString()}");

                startTime = DateTime.Now;
                var bytes = stream.ToArray();
                Console.WriteLine($"  |--> Stream to bytes time: {(DateTime.Now - startTime).ToString()}");

                startTime = DateTime.Now;
                File.WriteAllBytes(fileLocation, bytes);
                Console.WriteLine($"   |--> writing bytes to file time: {(DateTime.Now - startTime).ToString()}");
            }
        }
    }
}
