using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chapter09
{
    class Program
    {
        private static Int32 s_n = 0;

        private static void M(Int32 x=9, String s = "A", DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x={0}, s={1}, dt={2}, guid={3}", x, s, dt, guid);
        }

        static void Main(string[] args)
        {
            M();
            M(8, "X");
            M(5, "A", guid: Guid.NewGuid(), dt: DateTime.Now);
            M(s_n++, s_n++.ToString());
            M(s: (s_n++).ToString(), x: s_n++);

            String s1 = "자식 클래스에서 new 키워드를 써 ";
            s1 = null;
            Console.WriteLine(MakePath(s1));

            Int32 x;
            GetVal(out x);
            Console.WriteLine(x);

            // p252
            //FileStream fs;
            //StartProcessingFiles(out fs);
            //for(; fs != null; ContinueProcessingFiles(ref fs))
            //{
            //    //fs.Read();
            //}

            SomeMethod();
            SomeMethod2();

            //SomeType st;
            //GetAnObject(out st);

            DisplayTypes(new Object(), new Random(), "Jeff", 5);

            Console.ReadLine();
        }

        private static void DisplayTypes(params Object[] objects)
        {
            if (objects!=null)
            {
                foreach (Object o in objects)
                {
                    Console.WriteLine(o.GetType());
                }
            }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T t = b;
            b = a;
            a = t;
        }

        private static void GetAnObject(out SomeType st)
        {
            throw new NotImplementedException();
        }

        private static void GetAnObject(out Object o)
        {
            o = new String('X', 100);
        }

        public static String MakePath(String filename = null)
        {
            return String.Format(@"C:\{0}.txt", filename ?? "Untitled");
        }

        private static void ImplictlyTypedLocalVariables()
        {
            var name = "Jeff";
            ShowVariableType(name);

            //var n = null;
            var x = (String)null;
            ShowVariableType(x);

            var numbers = new Int32[] { 1, 2, 3, 4 };
            ShowVariableType(numbers);

            // 복잡한 타입의 변수를 적은 타이핑으로 쉽게 정의할 수 있다.
            var collection = new Dictionary<String, Single>() { { "Grant", 4.0f } };

            // System.Collections.Generic.Dictionary'2 [System.String, System.Single]를 표시한다.
            ShowVariableType(collection);

            foreach (var item in collection)
            {
                ShowVariableType(item);
            }
        }

        private static void ShowVariableType<T>(T t)
        {
            Console.WriteLine(typeof(T));
        }

        private static void GetVal(out Int32 v)
        {
            v = 10;     // 이 메서드는 v를 반드시 초기화해야 한다
        }

        private static void StartProcessingFiles(out FileStream fs)
        {
            fs = new FileStream("c:\test.txt", FileMode.Open);
        }

        private static void ContinueProcessingFiles(ref FileStream fs)
        {
            fs.Close();
            //if (noMoreFilesToProcess)
            //{
            //    fs = null;
            //}
            //else
            //{
            //    fs = new FileStream("c:\test.txt", FileMode.Open);
            //}
        }

        public static void Swap(ref Object a, ref Object b)
        {
            Object t = b;
            b = a;
            a = t;
        }

        public static void SomeMethod()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";

            // 참조로 전달되는 변수의 타입은 반드시 메서드가 기대하는 타입과 동일해야 한다.
            Object o1 = s1, o2 = s2;
            Swap(ref o1, ref o2);

            // Object 타입의 변수를 다시 String 타입의 변수로 캐스팅한다.
            s1 = (String)o1;
            s2 = (String)o2;

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }

        public static void SomeMethod2()
        {
            String s1 = "Jeffrey";
            String s2 = "Richter";

            Swap(ref s1, ref s2);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}
