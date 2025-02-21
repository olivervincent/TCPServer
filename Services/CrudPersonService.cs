using TCPEchoServer.Interfaces;
using TCPEchoServer.Models;
using TCPEchoServer.Repositories;

namespace TCPEchoServer.Services;

public class CrudPersonService : ICrudPersonService
{
    private readonly IPersonRepository _personRepository;
    private List<PersonModel> Persons { get; set; }
    
    public CrudPersonService()
    {
        _personRepository = new PersonRepository();
        Persons = new List<PersonModel>();
    }
    
    public Boolean CrudAction(string action, StreamReader reader, StreamWriter writer)
    {
        action = action.ToLower();
        var person = new PersonModel();
        switch (action)
        {
            case "create":
                writer.WriteLine("Enter person name:");
                writer.Flush();
                person.Name = reader.ReadLine();
                writer.WriteLine("Enter person phone:");
                writer.Flush();
                person.Phone = reader.ReadLine();
                writer.WriteLine("Enter person address:");
                writer.Flush();
                person.Address = reader.ReadLine();
                writer.WriteLine("Person created!");
                writer.Flush();
                Persons = _personRepository.CreatePerson(Persons, person);
                return false;
            case "edit":
                writer.WriteLine("Enter person id:");
                writer.Flush();
                person.Id = Convert.ToInt32(reader.ReadLine());
                if(!_personRepository.FindPerson(Persons, person))
                {
                    writer.WriteLine("Person with this Id not found!");
                    writer.Flush();
                    return false;
                }
                writer.WriteLine("Enter new person name:");
                writer.Flush();
                person.Name = reader.ReadLine();
                writer.WriteLine("Enter new person phone number:");
                writer.Flush();
                person.Phone = reader.ReadLine();
                writer.WriteLine("Enter new person address:");
                writer.Flush();
                person.Address = reader.ReadLine();
                writer.WriteLine("Person edited!");
                writer.Flush();
                Persons = _personRepository.EditPerson(Persons, person);
                return false;
            case "delete":
                writer.WriteLine("Enter person id:");
                writer.Flush();
                person.Id = Convert.ToInt32(reader.ReadLine());
                if(!_personRepository.FindPerson(Persons, person))
                {
                    writer.WriteLine("Person with this Id not found!");
                    writer.Flush();
                    return false;
                }
                writer.WriteLine("Person deleted!");
                writer.Flush();
                Persons = _personRepository.DeletePerson(Persons, person);
                return false;
            case "list":
                string personList = _personRepository.ListPerson(Persons);
                writer.WriteLine(personList);
                writer.Flush();
                return false;
            case "exit":
                writer.WriteLine("Closing connection..");
                writer.Flush();
                return true;
            case "help":
                writer.WriteLine("Available commands: create, edit, delete, list, exit");
                writer.Flush();
                return false;
            default:
                writer.WriteLine("Invalid action: must be create, edit, delete or list");
                writer.Flush();
                return false;
        }
    }
}