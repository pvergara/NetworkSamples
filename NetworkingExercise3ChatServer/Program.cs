using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkingExercise3ChatServer
{
    internal static class Program
    {
        private static readonly object LockObject = new();
        private static readonly Dictionary<Socket, StreamWriter> StreamWriterBySocket = new();
        private static readonly Dictionary<Socket, string> UserBySocket = new();

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
                    var hilo = new Thread(() => ClientRespondingThread(sClient));
                    hilo.Start();
                }
            }
        }

        private static void ClientRespondingThread(Socket socketClient)
        {
            var socketClientRemoteEndPoint = (IPEndPoint)socketClient.RemoteEndPoint!;
            Console.WriteLine("Client connected:{0} at port {1}", socketClientRemoteEndPoint.Address,
                socketClientRemoteEndPoint.Port);

            var networkStream = new NetworkStream(socketClient);
            AddClientEndPointToCollections(socketClient, networkStream);
            using (var streamReader = new StreamReader(networkStream, Encoding.UTF8))
            {
                const string welcome = "Welcome to chat server. Please provide username.";
                SendMessageToMe(welcome, socketClient);
                var message = "";

                var username = streamReader.ReadLine();
                AddUserToCollections(socketClient, username);

                SendMessageToAnotherUsers($@" Has been connected", socketClient);

                while (message != "#exit")
                {
                    try
                    {
                        message = streamReader.ReadLine();
                        if (message == "#list")
                        {
                            SendListOfUsersToMe(socketClient);
                        }
                        else if (message != "#exit")
                        {
                            SendMessageToAnotherUsers(message!, socketClient);
                        }
                    }
                    catch (IOException)
                    {
                        message = null;
                    }
                }

                SendMessageToAnotherUsers($@"Has been disconnected", socketClient);
                DeleteClientEndPointToAllCollections(socketClient);
                Console.WriteLine("Client disconnected.");
                Console.WriteLine("Connection closed");
            }

            socketClient.Close();
        }

        private static void DeleteClientEndPointToAllCollections(Socket socketClient)
        {
            lock (LockObject)
            {
                Program.StreamWriterBySocket.Remove(socketClient);
                Program.UserBySocket.Remove(socketClient);
            }
        }

        private static void SendMessageToAnotherUsers(string message, Socket key)
        {
            var anotherStreamWriterNotOfMe = new Dictionary<Socket, StreamWriter>();
            var username = "";

            lock (LockObject)
            {
                foreach (var pair in Program.StreamWriterBySocket)
                {
                    if (pair.Key != key)
                    {
                        anotherStreamWriterNotOfMe.Add(pair.Key, pair.Value);
                    }
                }

                // var anotherStreamWriterNotOfMe = StreamWriterBySocket.Where(pair => pair.Key != key).ToList();
                username = UserBySocket.GetValueOrDefault(key)!;
            }

            var address = ((IPEndPoint)key.RemoteEndPoint!).Address.ToString();
            var port = ((IPEndPoint)key.RemoteEndPoint).Port.ToString();
            foreach (var pair in anotherStreamWriterNotOfMe)
            {
                pair.Value.WriteLine($@"{username}.{address}:{port}: {@message}");
                pair.Value.Flush();
            }
        }


        private static void SendListOfUsersToMe(Socket socketClient)
        {
            var message = "";
            List<Socket> sockets;
            lock (LockObject)
            {
                sockets = StreamWriterBySocket.Select(pair => pair.Key).ToList();
            }

            foreach (var key in sockets)
            {
                var username = Program.UserBySocket.GetValueOrDefault(key);
                var address = ((IPEndPoint)key.RemoteEndPoint!).Address.ToString();
                var port = ((IPEndPoint)key.RemoteEndPoint).Port.ToString();
                message += $@"{username}.{address}:{port}" + Environment.NewLine;
            }

            SendMessageToMe(message, socketClient);
        }

        private static void SendMessageToMe(string message, Socket socketClient)
        {
            StreamWriter? streamWriter;
            lock (LockObject)
            {
                streamWriter = Program.StreamWriterBySocket.GetValueOrDefault(socketClient);
            }

            streamWriter?.WriteLine(message);
            streamWriter?.Flush();
        }

        private static void AddUserToCollections(Socket socketClient, string? username)
        {
            lock (LockObject)
            {
                Program.UserBySocket.Add(socketClient, username!);
            }
        }


        private static void AddClientEndPointToCollections(Socket socketClient, NetworkStream networkStream)
        {
            lock (LockObject)
            {
                var streamWriter = new StreamWriter(networkStream, Encoding.UTF8);
                Program.StreamWriterBySocket.Add(socketClient, streamWriter);
            }
        }
    }
}