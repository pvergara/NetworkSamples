using System.Net;
using System.Net.Sockets;

namespace NetworkingExercise1Client
{
    internal static class Program
    {
        private static void Main()
        {
            const string ipServer = "127.0.0.1";

            var ipEndPoint = new IPEndPoint(IPAddress.Parse(ipServer), 31416);
            Console.WriteLine("Starting client. Press a key to init connection");
            Console.ReadKey();
            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ipEndPoint);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                    e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
                Console.ReadKey();
                return;
            }

            var ieServer = (IPEndPoint)server.RemoteEndPoint!;
            Console.WriteLine("Server on IP: {0} at port {1}", ieServer.Address, ieServer.Port);

            using (var networkStream = new NetworkStream(server))
            using (var streamReader = new StreamReader(networkStream))
            using (var streamWriter = new StreamWriter(networkStream))
            {
                var message = streamReader.ReadLine();
                Console.WriteLine(message);
                
                var userMessage = Console.ReadLine();
                streamWriter.WriteLine(userMessage);
                streamWriter.Flush();
                
                message = streamReader.ReadToEnd();
                Console.WriteLine(message);
            }
        }
    }
}