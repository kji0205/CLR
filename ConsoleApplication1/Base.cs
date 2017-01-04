using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Base
    {
        private String m_name;

        // m_name 필드가 변경되기 전에 호출된다.
        protected virtual void OnNameChanging(String value) { }

        public String Name
        {
            get { return m_name; }
            set
            {
                OnNameChanging(value.ToUpper());    // 변경이 발생함을 알린다.
                m_name = value;                     // 필드를 변경한다.
            }
        }
    }

    internal class Derived : Base
    {
        protected override void OnNameChanging(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");
        }
    }
}
