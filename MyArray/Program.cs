using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArray
{
    class Program
    {
        static void Main(string[] args)
        {
            P447();
            P448();
            P451();

            Console.Read();
        }

        static void P440()
        {
            FileStream[,] fs2dim = new FileStream[5, 10];
            Object[,] o2dim = fs2dim;
            //Stream[] s1dim = (Stream[])o2dim;
            Stream[,] st2dim = (Stream[,])o2dim;
            Int32[] i1dim = new Int32[5];
            //Object[] o1dim = (Object[])i1dim;
            Object[] ob1dim = new Object[i1dim.Length];
            Array.Copy(i1dim, ob1dim, i1dim.Length);
        }

        static void P442()
        {
            // 값 타입 인스턴스를 저장할 수 있는 배열 생성
            MyValueType[] src = new MyValueType[100];
            // IComparable 인터페이스 타입의 참조를 저장할 수 있는 같은 크기의 배열 생성
            IComparable[] dest = new IComparable[src.Length];
            // IComparable 요소들의 배열을 원본 배열 요소의 박싱된 버전의 인스턴스들로 초기화
            Array.Copy(src, dest, src.Length);
        }

        static void P447()
        {
            // [2005..2009][1..4] 형태로 구성된 2차원 배열을 만들려고 한다.
            Int32[] lowerBounds = { 2005, 1 };
            Int32[] lengths = { 5, 4 };
            Decimal[,] quarterlyRevenue = (Decimal[,])
                Array.CreateInstance(typeof(Decimal), lengths, lowerBounds);

            Console.WriteLine("{0,4} {1,9} {2,9} {3,9} {4,9}", "Year", "Q1", "Q2", "Q3", "Q4");
            Int32 firstYear = quarterlyRevenue.GetLowerBound(0);
            Int32 lastYear = quarterlyRevenue.GetUpperBound(0);
            Int32 firstQuarter = quarterlyRevenue.GetLowerBound(1);
            Int32 lastQuarter = quarterlyRevenue.GetUpperBound(1);
            for (Int32 year = firstYear; year <= lastYear; year++)
            {
                Console.Write(year + "   ");
                for (Int32 quarter = firstQuarter; quarter < lastQuarter; quarter++)
                {
                    Console.Write("{0,9:C}  ", quarterlyRevenue[year, quarter]);
                }
                Console.WriteLine();
            }
        }

        static void P448()
        {
            Array a;

            // 1차원이면서 시작 인덱스가 0이고 원소가 없는 배열을 생성한다.
            a = new String[0];
            Console.WriteLine(a.GetType());

            // 1차원이면서 시작 인덱스가 0이고 원소가 없는 배열을 생성한다.
            a = Array.CreateInstance(typeof(String), new Int32[] { 0 }, new Int32[] { 0 });

            // 1차원이면서 시작 인덱스가 1이고 원소가 없는 배열을 생성한다.
            a = Array.CreateInstance(typeof(String), new Int32[] { 0 }, new Int32[] { 1 });
            Console.WriteLine(a.GetType());

            Console.WriteLine();

            // 2차원이면서 시작 인덱스가 0이고 원소가 없는 배열을 생성한다.
            a = new String[0, 0];
            Console.WriteLine(a.GetType());

            // 2차원이면서 시작 인덱스가 0이고 원소가 없는 배열을 생성한다.
            a = Array.CreateInstance(typeof(String), new int[] { 0, 0 }, new int[] { 0, 0 });
            Console.WriteLine(a.GetType());

            // 2차원이면서 시작 인덱스가 1이고 원소가 없는 배열을 생성한다.
            a = Array.CreateInstance(typeof(String), new Int32[] { 0, 0 }, new Int32[] { 1, 1 });
            Console.WriteLine(a.GetType());
        }

        private const Int32 c_numElements = 10000;
        static void P451()
        {
            Int32[,] a2Dim = new Int32[c_numElements, c_numElements];

            // 2차원 배열을 중첩 배열(벡터의 벡터) 형태로 정의하였다.
            Int32[][] aJagged = new Int32[c_numElements][];
            for (Int32 x=0; x < c_numElements; x++)
            {
                aJagged[x] = new Int32[c_numElements];
            }

            // 1: 배열의 모든 요소를 일반적인 기법을 사용하여 접근한다.
            Safe2DimArrayAccess(a2Dim);

            // 2: 배열의 모든 요소를 중첩 배열을 활용하여 접근한다.
            SafeJaggedArrayAccess(aJagged);

            // 3: 배열의 모든 요소를 안전하지 않은 코드를 사용하여 접근한다.
            Unsafe2DimArrayAccess(a2Dim);
        }

        private static Int32 Safe2DimArrayAccess(Int32[,] a)
        {
            Int32 sum = 0;
            for (Int32 x = 0; x < c_numElements; x++)
            {
                for (Int32 y = 0; y < c_numElements; y++)
                {
                    sum += a[x, y];
                }
            }
            return sum;
        }

        private static Int32 SafeJaggedArrayAccess(Int32[][] a)
        {
            Int32 sum = 0;
            for (Int32 x = 0; x < c_numElements; x++)
            {
                for (Int32 y = 0; y < c_numElements; y++)
                {
                    sum += a[x][y];
                }
            }
            return sum;
        }

        private static unsafe Int32 Unsafe2DimArrayAccess(Int32[,] a)
        {
            Int32 sum = 0;
            fixed(Int32* pi = a)
            {
                for (Int32 x = 0; x < c_numElements; x++)
                {
                    for (Int32 y = 0; y < c_numElements; y++)
                    {
                        sum += a[x, y];
                    }
                }
            }
            return sum;
        }
    }

    internal struct MyValueType : IComparable
    {
        public Int32 CompareTo(Object obj)
        {
            return 0;
        }
    }
}
