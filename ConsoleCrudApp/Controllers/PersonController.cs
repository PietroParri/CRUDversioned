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
    public void Print(string input, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(input);
        Console.ResetColor();
    }

    public void Create(string name, int age)
    {
        name = char.ToUpper(name[0]) + name.Substring(1);
        var person = new Person { Id = _nextId++, Name = name, Age = age };
        _people.Add(person);
    }

    public List<Person> GetAll()
    {
        return _people;
    }

    public bool Check(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null)
            return false;
        return true;
    }

    public bool Update(int id, string newName, int newAge)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);

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
