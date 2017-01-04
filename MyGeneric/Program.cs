using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypePerfTest();
            ReferenceTypePerfTest();

            Console.ReadKey();
        }

        private static void ValueTypePerfTest()
        {
            const Int32 count = 10000000;

            using (new OperationTimer("List<int32>"))
            {
                List<Int32> l = new List<int>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n);
                    Int32 x = l[n];
                }
                l = null;
            }

            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n);
                    Int32 x = (Int32)a[n];
                }
                a = null;
            }
        }

        private static void ReferenceTypePerfTest()
        {
            const Int32 count = 10000000;

            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<string>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X");
                    String x = l[n];
                }
                l = null;
            }

            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add("X");
                    String x = (String)a[n];
                }
                a = null;
            }
        }

        private static void SomeMethod()
        {
            List<DateTime> dtList = new List<DateTime>();
            dtList.Add(DateTime.Now);
            dtList.Add(DateTime.MinValue);
            //dtList.Add("1/1/2004");
            DateTime dt = dtList[0];
        }
    }
}
