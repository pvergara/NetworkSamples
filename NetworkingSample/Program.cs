using System.Net;
using System.Net.Sockets;

namespace NetworkingSample
{
    internal static class Program
    {
        private static void ShowNetInformation(string name)
        {
            var hostInfo = Dns.GetHostEntry(name);
            Console.WriteLine("Name: {0}", hostInfo.HostName);

            Console.WriteLine("IP list: ");
            foreach (var ip in hostInfo.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    Console.WriteLine($@"   {ip,16}");
            }
            Console.WriteLine("\n");
        }

        private static void Main()
        {
            var localHost = Dns.GetHostName();
            Console.WriteLine("Localhost name: {0} \n", localHost);
            ShowNetInformation(localHost);
            
            ShowNetInformation("duckduckgo.com");
            
            Console.ReadKey();
        }
    }
}