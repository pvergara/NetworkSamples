using System.Net;
using System.Net.Sockets;

namespace NetworkingExercise2Client;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ResultText.Text = SendMessageToServer(ServerIp.Text,ServerPort.Text,UserName.Text,"add");
    }

    private void button2_Click(object sender, EventArgs e)
    {
        ResultText.Text = SendMessageToServer(ServerIp.Text,ServerPort.Text,UserName.Text,"list");
    }

    private string SendMessageToServer(string serverIpText, string serverPortText, string userNameText, string command)
    {
        if (int.TryParse(serverPortText, out var serverPort) == false)
            return "Error parsing the port number";

        var ipEndPoint = new IPEndPoint(IPAddress.Parse(serverIpText), serverPort);
        var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            serverSocket.Connect(ipEndPoint);
        }
        catch (SocketException e)
        {
            return @$"Error connection: {e.Message}\nError code: {(SocketError)e.ErrorCode}({e.ErrorCode})";
        }

        var ieServer = (IPEndPoint)serverSocket.RemoteEndPoint!;
        Console.WriteLine(@$"Server on IP: {ieServer.Address} at port {ieServer.Port}");
        var message = "";
        using (var networkStream = new NetworkStream(serverSocket))
        using (var streamReader = new StreamReader(networkStream))
        using (var streamWriter = new StreamWriter(networkStream))
        {
            message = streamReader.ReadLine();
                
            
            streamWriter.WriteLine("user "+userNameText);
            streamWriter.Flush();

            streamWriter.WriteLine(command);
            streamWriter.Flush();
                
            message = streamReader.ReadToEnd();
            
        }

        return message;
    }
}