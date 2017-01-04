using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNullable
{
    class Class2
    {
        public static void ConversationAndCasting()
        {
            // Int32 타입과 Nullable<Int32> 타입 간의 암묵적 변환을 지원한다.
            Int32? a = 5;

            // Nullable<Int32>에 null 참조 대입을 지원한다.
            Int32? b = null;

            // Nullable<Int32> 타입에서 Int32 타입으로 명시적 변환을 지원한다.
            Int32 c = (Int32) a;

            // Nullable 기본 타입 간의 캐스팅을 지원한다.
            Double? d = 5;  // Int32->Double?
            Double? e = b;  // Int32?->Double?
        }

        private static Nullable<Int32> NullableCodeSize(Int32? a, Int32? b)
        {
            return a + b;
        }

        private static Nullable<Int32> NullableCodeSize2(Nullable<Int32> a, Nullable<Int32> b)
        {
            Nullable<Int32> nullable1 = a;
            Nullable<Int32> nullable2 = b;
            if (!(nullable1.HasValue & nullable2.HasValue))
            {
                return new Nullable<Int32>();
            }
            return new Nullable<Int32>(nullable1.GetValueOrDefault() + nullable2.GetValueOrDefault());
        }

        private static void NullCoalescingOperator()
        {
            Int32? b = null;

            //
            // x = (b.HasValue) ? b.Value : 123
            Int32 x = b ?? 123;
            Console.WriteLine(x);   // "123"

            // String temp = GetFilename();
            // filename = (temp != null) ? temp : "Untitled";
            String filename = GetFilename() ?? "Untitled";

            Func<String> f = () => GetFilename() ?? "Untitled";
            String s = GetFilename() ?? GetFilename2() ?? "Untitled";
        }

        private static String GetFilename()
        {
            return "";
        }
        private static String GetFilename2()
        {
            return "";
        }

        // Nullable 값 타입에 대한 박싱
        static void P522()
        {
            // Nullable<T> 타입에 대해 박싱할 경우 null 참조 또는 박싱된 T타입의 개체가 된다.
            Int32? n = null;
            Object o = n;       // o는 null 참조다.
            Console.WriteLine("o is null={0}", o == null);  // "True"
            n = 5;
            o = n;  // o는 Int32 타입의 박싱된 인스턴스다.
            Console.WriteLine("o's type={0}", o.GetType());     // "System.Int32"
        }

        public static void P523()
        {
            // 박싱된 Int32 타입의 인스턴스를 생성한다.
            Object o = 5;

            // Nullable<Int32>와 Int32 타입으로 언박싱한다.
            Int32? a = (Int32?) o;   // a = 5
            Int32 b = (Int32) o;     // b = 5

            // null 참조를 대입한다.
            o = null;

            // Nullable<Int32>와 Int32 타입으로 언박싱한다.
            a = (Int32?) o;  // a = null
            //b = (Int32) o;   // NullReferenceException

            // Nullable 값 타입에 대한 GetType 메서드 호출
            Int32? x = 5;

            // 아래 코드는 "System.Nullable<Int32>"가 아닌 "System.Int32"를 결과로 표시한다.
            Console.WriteLine(x.GetType());

            Int32? n = 5;
            // Int32 result = ((IComparable) (Int32) n).CompareTo(5);   // 불필요한 코드
            Int32 result = ((IComparable)n).CompareTo(5);   // 컴파일과 실행에 문제가 없다.
            Console.WriteLine(result);      // 0
        }
    }

    internal struct Point
    {
        private Int32 m_x, m_y;
        public Point(Int32 x, Int32 y) { m_x = x; m_y = y; }

        public static Boolean operator==(Point p1, Point p2)
        {
            return (p1.m_x == p2.m_x) && (p1.m_y == p2.m_y);
        }

        public static Boolean operator!=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }
    }

}
