using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBitFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            P429();
            P430();

            Console.Read();
        }

        static void P429()
        {
            String file = Assembly.GetEntryAssembly().Location;
            FileAttributes attributes = File.GetAttributes(file);
            Console.WriteLine("Is {0} hidden? {1}", file, (attributes & FileAttributes.Hidden) != 0);
        }

        [Flags]
        internal enum Actions
        {
            None=0,
            Read=0x0001,
            Write=0x0002,
            ReadWrite=Actions.Read|Actions.Write,
            Delete=0x0004,
            Query=0x0008,
            Sync=0x0010
        }

        static void P430()
        {
            Actions actions = Actions.Read | Actions.Delete;
            Console.WriteLine(actions.ToString());
        }
    }
}
