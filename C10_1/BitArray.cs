using System;
using System.Runtime.CompilerServices;

namespace C10_1
{
    public sealed class BitArray
    {
        // 비트 값을 보관하기 위한 private 바이트 배열이다.
        private Byte[] m_byteArray;
        private Int32 m_numBits;

        // 바이트 배열을 생성하고 모든 원소의 값을 0으로 초기화한다.
        public BitArray(Int32 numBits)
        {
            // 매개변수를 먼저 검사한다.
            if (numBits <= 0)
                throw new ArgumentOutOfRangeException("numBits must be > 0");

            // 비트 수를 저장한다.
            m_numBits = numBits;

            // 비트 배열을 위하여 바이트 배열을 할당한다.
            m_byteArray = new Byte[(numBits + 7) / 8];
        }

        // 이 멤버가 인덱서, 즉 매개변수가 있는 속성이다.
        [IndexerName("Bit")]
        public Boolean this[Int32 bitPos]
        {
            get
            {
                // 매개변수를 먼저 검사한다.
                if ((bitPos < 0) || (bitPos >= m_numBits))
                    throw new ArgumentOutOfRangeException("bitPos");

                // 특정 인덱스의 비트 상태를 반환한다.
                return (m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0;
            }

            set
            {
                if ((bitPos < 0) || (bitPos >= m_numBits))
                    throw new ArgumentOutOfRangeException("bitPos", bitPos.ToString());
                if (value)
                {
                    // 특정 인덱스의 비트를 1로 설정하낟.
                    m_byteArray[bitPos / 8] = (Byte)(m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
                }
                else
                {
                    // 특정 인덱스의 비트를 0으로 설정한다.
                    m_byteArray[bitPos/8]=(Byte)(m_byteArray[bitPos/8] & ~(1<<(bitPos%8)));

                }
            }
        }
    }
}
