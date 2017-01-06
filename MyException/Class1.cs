using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MyException
{
    class Class1
    {
    }

    public sealed class SomeType
    {
        private void SomeMethod()
        {
            FileStream fs = new FileStream(@"C:\Data.bin", FileMode.Open);
            try
            {
                // 파일 내의 첫 번째 바이트로 100을 나눈 후 그 결과를 출력한다.
                Console.WriteLine(100 / fs.ReadByte());
            }
            finally
            {
                // 예외 발생(예: 첫 번째 바이트가 0이라면) 여부와 상관 없이
                // 파일 닫기를 수행할 수 있도록 정리 코드를 finally 블록에 둔다.
                if (fs != null) fs.Dispose();
            }
        }

        private void SomeMethod2()
        {
            using (FileStream fs = new FileStream(@"C:\Data.bin", FileMode.Open))
            {
                // 파일 내의 첫 번째 바이트로 100을 나눈 후 그 결과를 출력한다.
                Console.WriteLine(100 / fs.ReadByte());
            }
        }

        public String CalculateSpreadsheetCell(Int32 row, Int32 column)
        {
            String result;
            try
            {
                result = "123";
            }
            catch (DivideByZeroException)
            {
                result = "Can't show value: Divide by zero";
            }
            catch (OverflowException)
            {
                result = "Can't show value: Too big";
            }
            return result;
        }

        public void SerializeObjectGraph(FileStream fs, IFormatter formatter, Object rootObj)
        {
            // 파일에서의 현재 위치를 저장해둔다.
            Int64 beforeSerialization = fs.Position;

            try
            {
                // 파일에 객체 그래프를 저장(serialize) 한다.
                formatter.Serialize(fs, rootObj);
            }
            catch   // 모든 예외를 잡는다.
            {
                // 만일 조금이라도 잘못된 부분이 있으면, 파일을 이전 상태로 재설정한다.
                fs.Position = beforeSerialization;

                // 파일 크기 재설정
                fs.SetLength(fs.Position);

                // 참고: 파일 저장이 실패하였을 때만 스트림을 재설정해야 하기 때문에
                // 앞쪽의 코드는 finally 블록에 둘 수 없다.

                // 호출자에게 예외가 발생하였음을 알려주기 위해서 동일한 예외를 다시 던진다.
                throw;
            }
        }
    }

    internal sealed class PhoneBook
    {
        private String m_pathname;  // 주소책의 파일 위치 지정

        // 다른 함수는 여기에 둔다.

        public String GetPhoneNumber(String name)
        {
            String phone;
            FileStream fs = null;
            try
            {
                fs = new FileStream(m_pathname, FileMode.Open);
                // 지정한 이름을 찾을 때까지 fs로부터 내용을 읽어 오는 코드를 여기에 둔다.
                phone = "0101231234";
            }
            catch (FileNotFoundException e)
            {
                // 찾고자 하는 이름을 포함하고, 원래 발생한 예외를 내부 예외로 취하는 다른 형태의 예외를 발생시킨다.
                //throw new NameNotFoundException(name, e);
                throw new InvalidCastException(name, e);
            }
            catch(IOException e)
            {
                // 찾고자 하는 이름을 포함하고, 원래 발생한 예외를 내부 예외로 취하는 다른 형태의 예외를 발생시킨다.
                throw new InvalidCastException(name, e);
            }
            finally
            {
                if (fs != null) fs.Close();
            }
            return phone;
        }

        private static void SomeMethod(String filename)
        {
            try
            {
                // 여기서는 어떤 작업이든 수행한다.
            }
            catch (IOException e)
            {
                // IOException 객체에 파일 이름을 더한다.
                e.Data.Add("Filename", filename);
                throw;  // 이제 정보가 추가된 동일 예외 객체를 다시 던진다.
            }
        }

        private static void Reflection(Object o)
        {
            try
            {
                // 이 객체의 DoSomething 메서드를 호출한다.
                var mi = o.GetType().GetMethod("SomeMethod");
                mi.Invoke(o, null);
            }
            catch(System.Reflection.TargetInvocationException e)
            {
                // CLR은 TargetInvocationException 타입으로 예외를 바꾸어 던진다.
                throw e.InnerException;     // 메서드가 발생시킨 실제 예외를 다시 던진다.
            }
        }
    }
}
