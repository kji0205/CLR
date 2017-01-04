using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Test
    {
    }

    internal class A
    {
        virtual public void hi()
        {
            Console.WriteLine("A::hi");
        }
    }

    internal class B : A
    {
        override public void hi()
        {
            //base.hi();
            Console.WriteLine("B::hi");
        }
    }

}
