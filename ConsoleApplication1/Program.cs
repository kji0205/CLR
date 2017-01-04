using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = 5;
            Rational r2 = 2.5F;

            Int32 x = (Int32)r1;
            Single s = (Single)r2;

            StringBuilder sb = new StringBuilder("Hello. My name is Jeff.");    // 최초의 문자열

            // 마침표를 느낌표로 바꾸고 느낌표가 몇 번재 문자인지 확인한다. (5)
            Int32 index = StringBuilderExtensions.IndexOf(sb.Replace('.', '!'), '!');
            Console.WriteLine(index);

            sb.Replace('.', '!');
            index = StringBuilderExtensions.IndexOf(sb, '!');
            index = sb.Replace('.', '!').IndexOf('!');
            Console.WriteLine(index);

            "Grant".ShowItems();
            new[] { "Jeff", "Kristin" }.ShowItems();
            new List<Int32> { 1, 2, 3 }.ShowItems();

            Action<Object> action = o => Console.WriteLine(o.GetType());
            action.InvokeAndCatch<NullReferenceException>(null);

            Action a = "Jeff".ShowItems;
            a();

            A a1 = new A();
            a1.hi();
            B b = new B();
            b.hi();

            Console.Read();
        }

        
    }

}
