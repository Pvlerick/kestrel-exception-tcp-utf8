using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Press any key to lauch request");
            Console.ReadKey();

            const string host = "localhost";
            const int port = 5000;

            var payload = Encoding.UTF8.GetBytes(
$@"GET http://{host}:{port}/?ù HTTP/1.1
Host: {host}:{port}
Content-Length: 0");

            var client = new TcpClient(host, port);
            using var stream = client.GetStream();

            await stream.WriteAsync(payload);

            var buffer = new byte[1024];
            var read = await stream.ReadAsync(buffer);
        }
    }
}
