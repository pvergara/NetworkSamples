using System.Net;
using System.Net.Sockets;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    
    public Form1()
    {

        InitializeComponent();
    }

    private void configuration_Button_Click(object sender, EventArgs e)
    {
        DialogForm DialogForm = new DialogForm();
        if (DialogForm.ShowDialog(this) == DialogResult.OK)
        {
            DialogForm.Text = "hey";
        }
        else
        {
            DialogForm.Text = "Cancelled";
        }

    }

    private void TimeButton_Click(object sender, EventArgs e)
    {
        this.ResultLabel.Text =  this.SendMessageToServer("time", "");
    }

    private void DateButton_Click(object sender, EventArgs e)
    {
        this.ResultLabel.Text =  this.SendMessageToServer("date", "");

    }

    private void AllButton_Click(object sender, EventArgs e)
    {
        this.ResultLabel.Text =  this.SendMessageToServer("all", "");
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        this.ResultLabel.Text =  this.SendMessageToServer("close", PasswordTextBox.Text);
    }

    private string? SendMessageToServer(String userMessage, String password)
    {
        const string ipServer = "127.0.0.1";

        var ipEndPoint = new IPEndPoint(IPAddress.Parse(ipServer), 31416);
        Console.WriteLine("Starting client. Press a key to init connection");
        var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            server.Connect(ipEndPoint);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Error connection: {0}\nError code: {1}({2})",
                e.Message, (SocketError)e.ErrorCode, e.ErrorCode);
            return "";
        }

        var ieServer = (IPEndPoint)server.RemoteEndPoint!;
        Console.WriteLine("Server on IP: {0} at port {1}", ieServer.Address, ieServer.Port);
        var message = "";
        
        using (var networkStream = new NetworkStream(server))
        using (var streamReader = new StreamReader(networkStream))
        using (var streamWriter = new StreamWriter(networkStream))
        {
            streamReader.ReadLine();

            if (password.Trim() != "")
                userMessage += $@" {password}"; 
            streamWriter.WriteLine(userMessage);
            streamWriter.Flush();
                
            message = streamReader.ReadLine();
            Console.WriteLine(message);
        }

        return message;
    }
}