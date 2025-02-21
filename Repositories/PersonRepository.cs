using System.Text;
using TCPEchoServer.Interfaces;
using TCPEchoServer.Models;

namespace TCPEchoServer.Repositories;

public class PersonRepository : IPersonRepository
{
    private List<PersonModel> Persons { get; set; }

    public PersonRepository()
    {
        Persons = new List<PersonModel>();
    }

    public void CreatePerson(PersonModel person)
    {
        person.Id = Persons.Count + 1;
        Persons.Add(person);
    }

    public void DeletePerson(PersonModel person)
    {
        Persons.Remove(Persons.Find(p => p.Id == person.Id));
    }

    public void EditPerson(PersonModel person)
    {
        var index = Persons.FindIndex(p => p.Id == person.Id);
        Persons[index] = person;
    }

    public bool FindPerson(PersonModel person)
    {
        return Persons.Exists(p => p.Id == person.Id);
    }

    public string ListPerson()
    {
        var sb = new StringBuilder();
        foreach (var person in Persons)
        {
            sb.AppendLine($"Id: {person.Id}");
            sb.AppendLine($"Name: {person.Name}");
            sb.AppendLine($"Address: {person.Address}");
            sb.AppendLine($"Phone: {person.Phone}");
        }
        if (sb.Length == 0)
        {
            sb.AppendLine("No persons found");
        }
        return sb.ToString();
    }
}