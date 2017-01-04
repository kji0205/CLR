using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyNullable
{
    class Class1
    {
    }

#if false
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Nullable<T> where T : struct
    {
        // 이 두 개 필드는 상태를 표현한다.
        private Boolean hasValue = false;   // null 여부를 관리한다.
        internal T value = default(T);      // 모든 비트가 0인 상태를 표현한다.

        public Nullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }

        public Boolean HasValue { get { return hasValue; ; } }

        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException("Nullable object must have a value.");
                }
                return value;
            }
        }
    }
#endif

}
