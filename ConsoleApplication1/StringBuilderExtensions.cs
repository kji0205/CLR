using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class StringBuilderExtensions
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (Int32 index = 0; index < sb.Length; index++)
            {
                if (sb[index] == value) return index;
            }
            return -1;
        }

        public static void ShowItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public static void InvokeAndCatch<TException>(this Action<Object> d, Object o) where TException : Exception
        {
            try { d(o); }
            catch (TException) { }
        }
    }
}
