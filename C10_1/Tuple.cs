using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_1
{
    [Serializable]
    class Tuple<T1>
    {
        private T1 m_Item1;
        public Tuple(T1 item1) { m_Item1 = item1; }
        public T1 Item1 { get { return m_Item1; } }
    }
}
