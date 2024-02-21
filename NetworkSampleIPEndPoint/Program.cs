using System.Net;

namespace NetworkSampleIPEndPoint
{
    internal static class Program
    {
        private static void Main()
        {
            ShowIdEndPointInfo(new IPEndPoint(IPAddress.Any, 1200));
            ShowIdEndPointInfo(new IPEndPoint(IPAddress.Loopback, 1200));
            ShowIdEndPointInfo(new IPEndPoint(IPAddress.Parse("192.168.1.45"), 1200));
            var ipEndPoint = new IPEndPoint(IPAddress.Parse("fe80::158b:39ab:d030:be5a%18"), 1200);
            ShowIdEndPointInfo(ipEndPoint);
            ipEndPoint.Port = 80;
            ipEndPoint.Address = IPAddress.Parse("80.1.12.128");
            Console.WriteLine("New End Point: {0}", ipEndPoint);
        }

        private static void ShowIdEndPointInfo(IPEndPoint ipEndPoint)
        {
            Console.WriteLine("IPEndPoint: {0}", ipEndPoint);
            Console.WriteLine("AddressFamily: {0}", ipEndPoint.AddressFamily);
            Console.WriteLine("Address: {0}, Puerto: {1}", ipEndPoint.Address, ipEndPoint.Port);
            Console.WriteLine("Ports range: {0}-{1}", IPEndPoint.MinPort, IPEndPoint.MaxPort);
            Console.WriteLine();
        }
    }
}