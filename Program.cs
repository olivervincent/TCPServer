using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using TCPEchoServer;

Console.WriteLine("TCP Server:");

TcpListener listener = new TcpListener(IPAddress.Any, 7);

listener.Start();

while (true)
{
    TcpClient client = listener.AcceptTcpClient();
    Task.Run(() => ClientHandler.HandleClient(client));
}
