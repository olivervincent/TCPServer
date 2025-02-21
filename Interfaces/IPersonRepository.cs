using TCPEchoServer.Models;

namespace TCPEchoServer.Interfaces;

public interface IPersonRepository
{
    public List<PersonModel> CreatePerson(List<PersonModel> persons, PersonModel person);
    public List<PersonModel> DeletePerson(List<PersonModel> persons, PersonModel person);
    public List<PersonModel> EditPerson(List<PersonModel> persons, PersonModel person);
    public string ListPerson(List<PersonModel> persons);
    public bool FindPerson(List<PersonModel> persons, PersonModel person);
    
}