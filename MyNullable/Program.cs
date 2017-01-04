using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNullable
{
    class Program
    {
        static void Main(string[] args)
        {
            Point? p1 = new Point(1, 1);
            Point? p2 = new Point(1, 2);

            Console.WriteLine("Are points equal? " + (p1 == p2).ToString());
            Console.WriteLine("Are points not equal? " + (p1 != p2).ToString());

            Class2.P523();

            Console.ReadKey();
        }
    }
}
