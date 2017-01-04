using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            P423();
            P424();
            P425();

            Console.ReadLine();
        }

        internal enum Color : byte
        {
            White, Red, Green, Blue, Orange
        }

        static void P423()
        {
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));
        }

        static void P424()
        {
            Color c = Color.Blue;
            Console.WriteLine(c);
            Console.WriteLine(c.ToString());
            Console.WriteLine(c.ToString("G"));
            Console.WriteLine(c.ToString("D"));
            Console.WriteLine(c.ToString("X"));
        }

        static void P425()
        {
            Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            Console.WriteLine("Number of symbols defined: " + colors.Length);
            Console.WriteLine("Value\tSymbol\n-----\t");
            foreach (Color c in colors)
            {
                // 각각의 기호를 10진수 형태와 일반 형태로 표기할 수 있다.
                Console.WriteLine("{0,5:D}\t{0:G}", c);
            }
        }

        static void P426()
        {
            // Orange는 4로 정의되어 있으므로 변수 c는 4로초기화된다.
            Color c = (Color)Enum.Parse(typeof(Color), "orange", true);

            // Brown은 정의되어 있지 않기 때문에 ArgumentException 예외 발생
            c = (Color)Enum.Parse(typeof(Color), "Brown", false);

            // Color 열거 타입의 인스턴스를 만들고 숫자 값 1을 저장한다.
            Enum.TryParse<Color>("1", false, out c);

            // Color 열거 타입의 인스턴스를 만들고 숫자 값 23을 저장한다.
            Enum.TryParse<Color>("23", false, out c);
        }
        

    }
}
