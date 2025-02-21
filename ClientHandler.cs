using System.Net.Sockets;
using TCPEchoServer.Services;

namespace TCPEchoServer;

public class ClientHandler
{
    public static void HandleClient(TcpClient client)
    {
        var crudProtokol = new CrudPersonService();
        Console.WriteLine(client.Client.RemoteEndPoint);
        NetworkStream ns = client.GetStream();
        StreamReader reader = new StreamReader(ns);
        StreamWriter writer = new StreamWriter(ns) {AutoFlush = true};

        bool isRunning = true;
        writer.WriteLine("Welcome to the CRUD server! Type help to see available commands.");
        
        while (isRunning)
        {
            string? message = reader.ReadLine();
            bool result = crudProtokol.CrudAction(message, reader, writer);
            isRunning = !result;
        }
        client.Close();
    }
}