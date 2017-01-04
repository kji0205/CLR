using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Security;
using System.Runtime.InteropServices;

namespace MyString
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Double d;
            d = Char.GetNumericValue('\u0033');
            Console.WriteLine(d.ToString());

            d = Char.GetNumericValue('\u00bc');
            Console.WriteLine(d.ToString());

            d = Char.GetNumericValue('A');
            Console.WriteLine(d.ToString());

            P372();
            P380();
            P400();

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(new BoldInt32s(), "{0} {1} {2:M}", "Jeff", 123, DateTime.Now);
            Console.WriteLine(sb);

            P406();
            P410();
            //P412();
            P416();
            P418();

            Console.Read();
        }

        static void P372()
        {
            Char c;
            Int32 n;

            c = (Char)65;
            Console.WriteLine(c);

            n = (Int32)c;
            Console.WriteLine(n);

            c = unchecked((Char)(65536 + 65));
            Console.WriteLine(c);

            c = Convert.ToChar(65);
            Console.WriteLine(c);

            n = Convert.ToInt32(c);
            Console.WriteLine(n);

            // Convert 타입의 최댓값 최솟값 범위 검사
            try
            {
                c = Convert.ToChar(70000);
                Console.WriteLine(c);
            }
            catch (OverflowException)
            {
                Console.WriteLine("70000을 Char 타입으로 변환할 수 없다.");
            }

            // 숫자 <-> 문자 간 변환을 IConvertible 인터페이스로 처리하는 경우
            c = ((IConvertible)65).ToChar(null);
            Console.WriteLine(c);

            n = ((IConvertible)c).ToInt32(null);
            Console.WriteLine(n);
        }

        static void P374()
        {
            String s = "Hi" + Environment.NewLine + "there.";
            Console.WriteLine(s);
        }

        static void P375()
        {
            String file = "C:\\Windows\\System32\\Notepad.exe";
            String file2 = @"C:\Windows\System32\Notepad.exe";
        }

        static void P380()
        {
            String s1 = "Strasse";
            String s2 = "straße";
            Boolean eq;

            // CompareOrdinal 에서는 다른 문자열로 판정한다.
            eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
            Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

            // 독일어(de)를 사용하는 독일(IDE) 거주자에게 있어 올바른 비교를 수행한다.
            CultureInfo ci = new CultureInfo("de-DE");

            // Compare에 문화권을 지정하여 비교하면 같은 문자열로 판정한다.
            eq = String.Compare(s1, s2, true, ci) == 0;
            Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");
        }

        static void P400()
        {
            String s = String.Format("On {0}, {1}, is {2} years old.", new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
            Console.WriteLine(s, CultureInfo.CurrentCulture);
            s = String.Format("On {0:D}, {1} is {2:E} years old.", new DateTime(2012, 4, 22, 14, 35, 5), "Aidan", 9);
            Console.WriteLine(s);
        }

        static void P406()
        {
            //Int32 x = Int32.Parse(" 123", NumberStyles.None, null);
            Int32 x = Int32.Parse(" 123", NumberStyles.AllowLeadingWhite, null);
            Int32 y = Int32.Parse("1A", NumberStyles.HexNumber, null);
            Console.WriteLine(y);
        }

        static void P410()
        {
            String s = "Hi there.";

            // UTF8으로 인코딩하거나 디코딩할 수 있는 객체를 가져온다.
            // 이 객체는 Encoding 클래스를 상속한 클래스의 인스턴스다.
            Encoding encodingUTF8 = Encoding.UTF8;

            // 문자열을 바이트 배열로 인코딩한다.
            Byte[] encodeBytes = encodingUTF8.GetBytes(s);

            // 인코딩된 바이트 배열을 표시한다.
            Console.WriteLine("Encoded bytes: " + BitConverter.ToString(encodeBytes));

            // 인코딩된 바이트 배열을 디코딩하여 문자열로 복원한다.
            String decodedString = encodingUTF8.GetString(encodeBytes);

            // 디코딩된 문자열을 보여준다.
            Console.WriteLine("Decoded string: " + decodedString);
        }

        static void P412()
        {
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding e = ei.GetEncoding();
                Console.WriteLine("{1}{0}" +
                    "\tCodePage={2}, WindowsCodePage={3}{0}" +
                    "\tWebName={4}, HeaderName={5}, BodyName={6}{0}" +
                    "\tIsBrowserDisplay={7}, IsBrowserSave={8}{0}" +
                    "tIsMailNewDisplay={9}, IsMailNewsSave={10}{0}",

                    Environment.NewLine,
                    e.EncodingName, e.CodePage, e.WindowsCodePage,
                    e.WebName, e.HeaderName, e.BodyName,
                    e.IsBrowserDisplay, e.IsBrowserSave,
                    e.IsMailNewsDisplay, e.IsMailNewsSave
                    );
            }
        }

        static void P416()
        {
            // 임의로 10바이트를 생성한다.
            Byte[] bytes = new Byte[10];
            new Random().NextBytes(bytes);

            // 바이트 배열을 표시한다.
            Console.WriteLine(BitConverter.ToString(bytes));

            // 바이트 배열을 base-64 문자열로 디코딩하고 표시한다.
            String s = Convert.ToBase64String(bytes);
            Console.WriteLine(s);

            // base-64 문자열을 바이트 배열로 인코딩하고 표시한다.
            bytes = Convert.FromBase64String(s);
            Console.WriteLine(BitConverter.ToString(bytes));
        }

        static void P418()
        {
            using (SecureString ss=new SecureString())
            {
                Console.Write("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;

                    //SecureString에 비밀번호 문자들을 더한다.
                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                Console.WriteLine();

                // 비밀번호 입력이 끝나면, 그 안의 내용을 보여주는 시연용 메서드를 호출한다.
                DisplaySecureString(ss);
            }
        }

        private unsafe static void DisplaySecureString(SecureString ss)
        {
            Char* pc = null;
            try
            {
                // SecureString을 관리되지 않는 메모리 버퍼로 복원한다.
                pc = (char*)Marshal.SecureStringToCoTaskMemUnicode(ss);

                // 복원된 SecureString의 내용을 보관하는 관리되지 않는 메모리에 접근한다.
                for (Int32 index = 0; pc[index] != 0; index++)
                    Console.Write(pc[index]);
            }
            finally
            {
                if (pc != null)
                    Marshal.ZeroFreeCoTaskMemUnicode((IntPtr)pc);
            }
        }
    }
    
}


// 사용자 정의 서식 지정 구현하기
internal sealed class BoldInt32s : IFormatProvider, ICustomFormatter
{
    public Object GetFormat(Type formatType)
    {
        return System.Threading.Thread.CurrentThread.CurrentCulture.GetFormat(formatType);
    }

    public String Format(String format, Object arg, IFormatProvider formatProvider)
    {
        String s;

        IFormattable formattable = arg as IFormattable;
        if (formattable == null) s = arg.ToString();
        else s = formattable.ToString(format, formatProvider);

        if (arg.GetType() == typeof(Int32))
            return "<B>" + s + "</B>";
        return s;
    }
}