using TCPEchoServer.Models;

namespace TCPEchoServer.Interfaces;

public interface IPersonRepository
{
    void CreatePerson(PersonModel person);
    void DeletePerson(PersonModel person);
    void EditPerson(PersonModel person);
    string ListPerson();
    bool FindPerson(PersonModel person);
}