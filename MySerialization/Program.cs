using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySerialization
{
    internal static class QuickStart
    {
        static void Main(string[] args)
        {
            // 스트림으로 serialize할 객체 그래프를 생성한다.
            var objectGraph = new List<String> { "Jeff", "Kristin", "Aidan", "Grant" };
            Stream stream = SerializeToMemory(objectGraph);

            // 데모를 위해서 모든 것을 초기화한다.
            stream.Position = 0;
            objectGraph = null;

            // 객체를 deserialize한 후, 제대로 동작하는지 검증한다.
            objectGraph = (List<String>)DeserializeFromMemory(stream);
            foreach (var s in objectGraph) Console.WriteLine(s);

            Console.ReadLine();
        }

        private static MemoryStream SerializeToMemory(Object objectGraph)
        {
            // serailize한 객체를 저장할 스트림을 생성한다.
            MemoryStream stream = new MemoryStream();

            // 모든 복잡한 작업을 전임할 serialization 포맷터를 생성한다.
            BinaryFormatter formatter = new BinaryFormatter();

            // 포맷터에게 객체를 stream으로 serialize해줄 것을 요청하낟.
            formatter.Serialize(stream, objectGraph);

            // 호출자에게 serialize된 객체 스트림을 반환한다.
            return stream;
        }

        private static Object DeserializeFromMemory(Stream stream)
        {
            // 모든 복잡한 작업을 전임할 serialization 포맷터를 생성한다.
            BinaryFormatter formatter = new BinaryFormatter();

            // 포맷터에게 스트림으로부터 객체를 deserialize해줄 것을 요청한다.
            return formatter.Deserialize(stream);
        }
    }
}
