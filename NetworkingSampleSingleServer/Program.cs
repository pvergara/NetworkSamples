using System.Net;
using System.Net.Sockets;

namespace NetworkingSampleSingleServer
{
    internal static class Program
    {
        private static void Main()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 31416);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                socket.Bind(ipEndPoint);
                socket.Listen(10);
                Console.WriteLine($"Server listening at port: {ipEndPoint.Port}");
                var sClient = socket.Accept();
                var ieClient = (IPEndPoint)sClient.RemoteEndPoint!;
                Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address, ieClient.Port);
                using (var networkStream = new NetworkStream(sClient))
                using (var streamReader = new StreamReader(networkStream))
                using (var streamWriter = new StreamWriter(networkStream))
                {
                    const string welcome = "Welcome to The Echo-Logic, Odd, Desiderable, Incredible, and Javaless Echo Server(T.E.L.O.D.I.J.E. Server)";
                    streamWriter.WriteLine(welcome);
                    streamWriter.Flush();
                    var message = "";
                    while (message != null)
                    {
                        try
                        {
                            message = streamReader.ReadLine();
                            if (message != null)
                            {
                                Console.WriteLine(message);
                                streamWriter.WriteLine(message.ToUpper());
                                streamWriter.Flush();
                            }
                        }
                        catch (IOException)
                        {
                            message = null;
                        }
                    }

                    Console.WriteLine("Client disconnected.");
                    Console.WriteLine("Connection closed");
                }

                sClient.Close();
            }
        }
    }
}