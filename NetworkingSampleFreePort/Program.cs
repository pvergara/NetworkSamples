using System.Net;
using System.Net.Sockets;

namespace NetworkingSampleFreePort
{
    internal static class Program
    {
         private const int Port = 135;

        private static void Main()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, Port);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    socket.Bind(ipEndPoint);
                    Console.WriteLine($"Port {Port} free");
                }
                catch (SocketException e) when (e.ErrorCode is (int)SocketError.AddressAlreadyInUse) 
                {
                    Console.WriteLine($"Port {Port} in use");
                }
            }
        }
    }
}