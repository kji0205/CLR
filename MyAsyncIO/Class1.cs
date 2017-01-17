using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAsyncIO
{
    class Class1
    {
        private static async Task<String> IssueClientRequestAsync(String serverName, String message)
        {
            using (var pipe = new NamedPipeClientStream(serverName, "PipeName", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough))
            {
                pipe.Connect();     // ReadMode를 설정하기 이전에 반드시 연결되어야 한다.
                pipe.ReadMode = PipeTransmissionMode.Message;

                // 서버에 비동기로 데이터를 전송한다.
                Byte[] request = Encoding.UTF8.GetBytes(message);
                await pipe.WriteAsync(request, 0, request.Length);

                // 서버로부터 비동기로 데이터를 수신한다.
                Byte[] response = new Byte[1000];
                Int32 bytesRead = await pipe.ReadAsync(response, 0, request.Length);
                return Encoding.UTF8.GetString(response, 0, bytesRead);
            }   // 파이프를 닫는다.
        }
    }
}
