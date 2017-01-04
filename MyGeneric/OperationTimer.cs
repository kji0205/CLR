using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MyGeneric
{
    internal sealed class OperationTimer : IDisposable
    {
        private Stopwatch m_stopwatch;
        private String m_text;
        private Int32 m_collectionCount;

        public OperationTimer(String text)
        {
            PrepareForOperation();

            m_text = text;
            m_collectionCount = GC.CollectionCount(0);

            m_stopwatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}", (m_stopwatch.Elapsed), GC.CollectionCount(0) - m_collectionCount, m_text);
        }

        private static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
