using System.Net;
using System.Net.Sockets;

namespace NetworkingExercise1Server
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

                while (true)
                {
                    var sClient = socket.Accept();
                    var hilo = new Thread(()=>ClientRespondingThread(sClient));
                    hilo.Start();
                }
            }
        }

        private static void ClientRespondingThread(Socket socketClient)
        {
            
            var ieClient = (IPEndPoint)socketClient.RemoteEndPoint!;
            Console.WriteLine("Client connected:{0} at port {1}", ieClient.Address, ieClient.Port);
            using (var networkStream = new NetworkStream(socketClient))
            using (var streamReader = new StreamReader(networkStream))
            using (var streamWriter = new StreamWriter(networkStream))
            {
                const string welcome = "Welcome to The Echo-Logic, Odd, Desiderable, Incredible, and Javaless Echo Server(T.E.L.O.D.I.J.E. Server)";
                streamWriter.WriteLine(welcome);
                streamWriter.Flush();
                var message = "";
                    try
                    {
                        message = streamReader.ReadLine();
                        Console.WriteLine(message);
                        switch (message)
                        {
                            case "time":
                                streamWriter.WriteLine(@$"{DateTime.Now:t}");
                                break;
                            case "date":
                                streamWriter.WriteLine(@$"{DateTime.Now:d}");
                                break;
                            case "all":
                                streamWriter.WriteLine(@$"{DateTime.Now:F}");
                                break;
                                
                        }
                        streamWriter.Flush();
                    }
                    catch (IOException)
                    {
                        message = null;
                    }

            }

            socketClient.Close();
        }
    }
}