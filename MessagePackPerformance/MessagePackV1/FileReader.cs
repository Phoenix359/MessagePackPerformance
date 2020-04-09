using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MessagePackV1
{
    public static class FileReader
    {
        public static string GetFileLocation(string filename)
        {
            var directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent
            (
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            )
            .FullName).FullName).FullName).FullName + "\\Shared";

            return Directory.GetFiles(directory, filename).First();
        }

        public static T GetObjectFromBinaryFile<T>(string fileName)
        {
            if (!fileName.EndsWith(".bin"))
            {
                fileName += ".bin";
            }

            var binaryFileLocation = GetFileLocation(fileName);
            if (string.IsNullOrWhiteSpace(binaryFileLocation))
            {
                return default;
            }

            return Deserialize<T>(binaryFileLocation);
        }

        private static T Deserialize<T>(string fileLocation)
        {
            var startTime = DateTime.Now;
            var bytes = File.ReadAllBytes(fileLocation);
            Console.WriteLine($" |--> Reading bytes from file time: {(DateTime.Now - startTime).ToString()}");

            using (var stream = new MemoryStream())
            {
                var serializer = new MessagePackSerializerV1();

                startTime = DateTime.Now;
                stream.Write(bytes);
                stream.Position = 0;
                Console.WriteLine($"  |--> Writing bytes to memory stream: {(DateTime.Now - startTime).ToString()}");

                startTime = DateTime.Now;
                var obj = serializer.Deserialize<T>(stream);
                Console.WriteLine($"   |--> MessagePack V1 deserialization time from stream: {(DateTime.Now - startTime).ToString()}");

                return obj;
            }
        }
    }
}
