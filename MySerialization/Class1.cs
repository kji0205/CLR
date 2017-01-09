using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MySerialization
{
    class Class1
    {
        //private static List<Customer> s_customers = new List<Customer>();
        private static Object DeepClone(Object original)
        {
            // 임시 메모리 스트림을 생성한다.
            using (MemoryStream stream=new MemoryStream())
            {
                // 모두 복잡한 작업을 전임할 serialization 포맷터를 생성한다.
                BinaryFormatter formatter = new BinaryFormatter();

                // 이 행은 이번 장의 "스트리밍 컨텍스트" 절에서 설명할 것이다.
                formatter.Context = new System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone);

                // 객체 그래프를 메모리 스트림으로 serialize한다.
                formatter.Serialize(stream, original);

                // deserialize 이전에 메모리 스트림의 시작 위치로 돌아간다.
                stream.Position = 0;

                // 객체 그래프를 deserialize하여 새로운 객체를 생성한 후 호출자에게 이 객체를 반환한다. 전체 복사(deep copy)
                return formatter.Deserialize(stream);
            }
        }

        private static void RestoreApplicationState(Stream stream)
        {
            // 모든 복잡한 작업을 전임할 serialization 포맷터를 생성한다.
            BinaryFormatter formatter = new BinaryFormatter();

            // 음용프로그램의 상태를 복원하기 위해서 deserialize를 수행한다. (serialize하였던 순서와 일치해야 한다.)
            // To Do
        }

        public static void OptInSerialization()
        {
            Point pt = new Point { x = 1, y = 2 };
            using (var stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, pt);
            }
        }
    }

    [Serializable]
    internal struct Point { public Int32 x, y; }

    
}
