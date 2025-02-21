using TCPEchoServer.Interfaces;
using TCPEchoServer.Models;
using TCPEchoServer.Repositories;

namespace TCPEchoServer.Services;

public class CrudPersonService : ICrudPersonService
{
    private readonly IPersonRepository _personRepository;
    
    public CrudPersonService()
    {
        _personRepository = new PersonRepository();
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
                _personRepository.CreatePerson(person);
                return false;
            case "edit":
                writer.WriteLine("Enter person id:");
                writer.Flush();
                person.Id = Convert.ToInt32(reader.ReadLine());
                if(!_personRepository.FindPerson(person))
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
                _personRepository.EditPerson(person);
                return false;
            case "delete":
                writer.WriteLine("Enter person id:");
                writer.Flush();
                person.Id = Convert.ToInt32(reader.ReadLine());
                if(!_personRepository.FindPerson(person))
                {
                    writer.WriteLine("Person with this Id not found!");
                    writer.Flush();
                    return false;
                }
                writer.WriteLine("Person deleted!");
                writer.Flush();
                _personRepository.DeletePerson(person);
                return false;
            case "list":
                string personList = _personRepository.ListPerson();
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