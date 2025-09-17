using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCrudApp.Models;

namespace ConsoleCrudApp.Controllers;

public class PersonController
{
    private readonly List<Person> _people = new();
    private int _nextId = 1;

    public void Create(string name, int age)
    {
        var person = new Person { Id = _nextId++, Name = name, Age = age };
        _people.Add(person);
        Console.WriteLine("Person added successfully!");
    }

    public List<Person> GetAll()
    {
        return _people;
    }

    public bool Update(int id, string newName, int newAge)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null) return false;

        person.Name = newName;
        person.Age = newAge;
        return true;
    }

    public bool Delete(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null) return false;

        _people.Remove(person);
        return true;
    }
}
