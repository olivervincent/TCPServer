using System.Text;
using TCPEchoServer.Interfaces;
using TCPEchoServer.Models;

namespace TCPEchoServer.Repositories;

public class PersonRepository : IPersonRepository
{
    public List<PersonModel> CreatePerson(List<PersonModel> persons, PersonModel person)
    {
        person.Id = persons.Count + 1;
        persons.Add(person);
        return persons;
    }
    
    public List<PersonModel> DeletePerson(List<PersonModel> persons, PersonModel person)
    {
        persons.Remove(persons.Find(p => p.Id == person.Id));
        return persons;
    }
    
    public List<PersonModel> EditPerson(List<PersonModel> persons, PersonModel person)
    {
        var index = persons.FindIndex(p => p.Id == person.Id);
        persons[index] = person;
        return persons;
    }
    
    public bool FindPerson(List<PersonModel> persons, PersonModel person)
    {
        return persons.Exists(p => p.Id == person.Id);
    }
    
    public string ListPerson(List<PersonModel> persons)
    {
        var sb = new StringBuilder();
        foreach (var person in persons)
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