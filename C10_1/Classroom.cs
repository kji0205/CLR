using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_1
{
    public sealed class Classroom
    {
        private List<String> m_students = new List<string>();
        public List<String> Students { get { return m_students; } }

        public Classroom() { }
    }
}
