using TCPEchoServer.Models;

namespace TCPEchoServer.Interfaces;

public interface ICrudPersonService
{
    Boolean CrudAction(string action, StreamReader reader, StreamWriter writer);
}