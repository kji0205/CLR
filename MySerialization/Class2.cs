using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MySerialization
{
    class Class2
    {
    }

    [Serializable]
    internal class Circle
    {
        private Double m_radius;

        [NonSerialized]
        private Double m_area;

        public Circle(Double radius)
        {
            m_radius = radius;
            m_area = Math.PI * m_radius * m_radius;
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            m_area = Math.PI * m_radius * m_radius;
        }
    }

    [Serializable]
    public class MyType
    {
        Int32 x, y; [NonSerialized]
        Int32 sum;

        public MyType(Int32 x, Int32 y)
        {
            this.x = x;this.y = y;sum = x + y;
        }

        [OnDeserialized]
        private void OnDeserializing(StreamingContext context)
        {
            // 예: 새롭게 생성되는 객체의 필드 값들의 기본값을 채운다.
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            // 예: 필드들의 일시적인 유지하는 상태를 초기화한다.
            sum = x + y;
        }

        [OnSerializing]
        private void OnSerialized(StreamingContext context)
        {
            // 예: serialize를 수행한 이후에 상태를 복원한다.
        }
    }
}
