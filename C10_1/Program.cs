using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s = new Employee { Name = "Jeff", Age = 45 }.ToString().ToUpper();
            Console.WriteLine(s);

            M();
            P277();
            P282();

            Console.ReadKey();
        }

        public static void M()
        {
            Classroom classroom = new Classroom
            {
                Students = { "Jeff", "Kristin", "Aidan", "Grant" }
            };

            foreach (var student in classroom.Students)
                Console.WriteLine(student);
        }

        public static void P277()
        {
            String myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var query =
                from pathname in Directory.GetFiles(myDocuments)
                let LastWriteTime = File.GetLastWriteTime(pathname)
                where LastWriteTime > (DateTime.Now - TimeSpan.FromDays(7))
                orderby LastWriteTime
                select new { Path = pathname, LastWriteTime };

            foreach (var file in query)
                Console.WriteLine("LastWriteTime={0}, Path={1}", file.LastWriteTime, file.Path);
        }

        public static void P282()
        {
            // 14비트를 저장하는 BitArray 객체를 생성한다.
            BitArray ba = new BitArray(14);

            // 모든 짝수 번째 비트에 대해서만 set 접근자 메서드를 호출하여 1로 설정한다.
            for(Int32 x=0; x<14; x++)
            {
                ba[x] = (x % 2 == 0);
            }

            // get 접근자 메서드를 이용하여 모든 비트의 상태를 확인한다.
            for (Int32 x = 0; x < 14; x++)
            {
                Console.WriteLine("Bit " + x + " is " + (ba[x] ? "On" : "Off"));
            }
        }
    }
}
