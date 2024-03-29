﻿using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetworkingExercise4Server;

[SuppressMessage("ReSharper", "UnusedMember.Local")]
[SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Local")]
public class ShiftServer
{
    private IList<string>? _users = new List<string>();    
    private IList<string>? _waitQueue = new List<string>();
    public int AdminPassword { get; } = 1234;

    private void ReadNames(string filePath)
    {
        using (var streamReader = new StreamReader(filePath,Encoding.UTF8))
        {
            var usersAsString = streamReader.ReadLine();
            this._users = usersAsString?.Split(";").ToList() ?? throw new InvalidOperationException();
            this._users.Remove("");
            Console.WriteLine(string.Join(Environment.NewLine,this._users));
        }
    } 
    
    private int ReadPin(string filePath)
    {
        int pingAsInteger;
        try
        {
            using var streamReader = new BinaryReader(new FileStream(filePath,FileMode.Open));
            pingAsInteger = streamReader.ReadInt32();
            Console.WriteLine(pingAsInteger);
        }catch (FileNotFoundException)
        {
            return 1234;
        }

        return pingAsInteger;
    }

    private void WritePin(string filePath,int newPin)
    {
        using var streamReader = new BinaryWriter(new FileStream(filePath,FileMode.OpenOrCreate));
        streamReader.Write(newPin);
    }

    
    public void Init()
    {
        ReadNames($@"{Environment.GetEnvironmentVariable("userprofile")}\usuarios.txt");
            
        var ipEndPoint = new IPEndPoint(IPAddress.Any, 31416);
        using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        {
            socket.Bind(ipEndPoint);
            socket.Listen(10);
            Console.WriteLine($"Server listening at port: {ipEndPoint.Port}");

            while (true)
            {
                var sClient = socket.Accept();
                var hilo = new Thread(() => ManageShiftServerPerThread(sClient));
                hilo.Start();
            }
        }
    }

    private void ManageShiftServerPerThread(Socket socketClient)
    {
        bool mustShutdown = false;
        var socketClientRemoteEndPoint = (IPEndPoint)socketClient.RemoteEndPoint!;
            Console.WriteLine("Client connected:{0} at port {1}", socketClientRemoteEndPoint.Address, socketClientRemoteEndPoint.Port);
            using (var networkStream = new NetworkStream(socketClient))
            using (var streamReader = new StreamReader(networkStream))
            using (var streamWriter = new StreamWriter(networkStream))
            {
                const string welcome = "Welcome to The Echo-Logic, Odd, Desiderable, Incredible, and Javaless Echo Server(T.E.L.O.D.I.J.E. Server)";
                streamWriter.WriteLine(welcome);
                streamWriter.Flush();
                string? message;
                try
                {
                    message = streamReader.ReadLine();
                    Console.WriteLine(message);
                    
                    if (message!.StartsWith("user"))
                    {
                        var userName = message.Trim().Replace("user ","");
                        if (userName == "")
                        {
                            streamWriter.WriteLine("Empty user");
                            streamWriter.Flush();
                        }else if (!this._users!.Any(userName.Equals))
                        {
                            streamWriter.WriteLine(@$"User {userName} does not exist");
                            streamWriter.Flush();
                        }
                        else
                        {
                            streamWriter.WriteLine(@$"User {userName} OK");
                            streamWriter.Flush();

                            message = streamReader.ReadLine();
                            Console.WriteLine(message);
                            if (message == "add")
                            {
                                if (this._waitQueue!.Any(userNameAndDate => userNameAndDate.StartsWith(userName)))
                                {
                                    streamWriter.WriteLine(@$"User {userName} already added");
                                    streamWriter.Flush();
                                }
                                else
                                {
                                    this._waitQueue!.Add($@"{userName} {DateTime.Now:f}");
                                    streamWriter.WriteLine(@$"User {userName} added");
                                    streamWriter.Flush();
                                }
                            }else if (message == "list")
                            {
                                streamWriter.WriteLine(@$"{string.Join(Environment.NewLine,this._waitQueue!)}");
                                streamWriter.Flush();
                            }
                        }
                    }else if (message.StartsWith("admin"))
                    {
                        int adminPassword = ReadPin(@$"{Environment.GetEnvironmentVariable("userprofile")}\pin.bin");

                        if (!int.TryParse(message.Trim().Replace("admin ", ""), out var guessAdminPassword))
                        {
                            streamWriter.WriteLine(@$"Wrong admin password");
                            streamWriter.Flush();
                        }
                        if (adminPassword != guessAdminPassword)
                        {
                            streamWriter.WriteLine(@$"Admin Password {guessAdminPassword} does not match");
                            streamWriter.Flush();
                        }
                        else
                        {
                            var mustExit = false;
                            while (!mustExit)
                            {
                                message = streamReader.ReadLine();
                                if (message == "exit")
                                {
                                    mustExit = true;
                                    streamWriter.WriteLine(@$"Bye Bye");
                                    streamWriter.Flush();
                                } else if (message == "shutdown")
                                {
                                    mustExit = true;
                                    mustShutdown = true;
                                    streamWriter.WriteLine(@$"Bye Bye and cambuuuum");
                                    streamWriter.Flush();
                                } else if (message!.StartsWith("chpin"))
                                {
                                    if (!int.TryParse(message.Trim().Replace("chpin ", ""), out var newAdminPassword))
                                    {
                                        streamWriter.WriteLine(@$"Password incorrect");
                                        streamWriter.Flush();
                                    }
                                    else
                                    {
                                        WritePin(@$"{Environment.GetEnvironmentVariable("userprofile")}\pin.bin",
                                            newAdminPassword);
                                        streamWriter.WriteLine(@$"The password has been changed");
                                        streamWriter.Flush();
                                    }
                                }else if (message == "list")
                                {
                                    streamWriter.WriteLine(@$"{string.Join(Environment.NewLine,this._waitQueue!)}");
                                    streamWriter.Flush();
                                }else if (message.StartsWith("del"))
                                {
                                    if (!int.TryParse(message.Trim().Replace("del ", ""), out var position))
                                    {
                                        streamWriter.WriteLine(@$"Position incorrect");
                                        streamWriter.Flush();
                                    }
                                    else
                                    {
                                        if (position < 0 || position >= this._waitQueue!.Count)
                                        {
                                            streamWriter.WriteLine(@$"Position incorrect");
                                            streamWriter.Flush();
                                        }
                                        else
                                        {
                                            this._waitQueue.RemoveAt(position);
                                            streamWriter.WriteLine(@$"User has been deleted");
                                            streamWriter.Flush();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (IOException)
                {
                }
            }

            socketClient.Close();
            Thread.CurrentThread.Interrupt();
            
            Console.WriteLine("Closing client");
            if (!mustShutdown) return;
            Console.WriteLine("Shutdown server");
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}