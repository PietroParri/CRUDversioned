using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCrudApp.Controllers;
using ConsoleCrudApp.Models;

namespace ConsoleCrudApp.Views;

public class PersonView
{
    public void Show(List<Person> people)
    {
        if (people.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No people registered.");
            Console.ResetColor();
            return;
        }
        else
        {
            Console.WriteLine("List of people registered:");
            foreach (var person in people)
            {
                Console.WriteLine($"ID: {person.Id} | Name: {person.Name} | Age: {person.Age}");
            }
        }
    }
}
