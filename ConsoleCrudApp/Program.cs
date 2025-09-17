using ConsoleCrudApp.Controllers;
using ConsoleCrudApp.Views;

var _controller = new PersonController();
var view = new PersonView();

Console.WriteLine("CRUDversioned v.1.0 (17/09/2025)");
Console.WriteLine("Made by Pietro Borges Parri\n");

while (true)
{
    Console.WriteLine("\nOptions:");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("(1) Add Person");
    Console.WriteLine("(2) List People");
    Console.WriteLine("(3) Update Person");
    Console.WriteLine("(4) Remove Person");
    Console.WriteLine("(0) Exit");
    Console.ResetColor();
    Console.Write("Choose an option: ");

    var option = Console.ReadLine();

    Console.Clear();
    switch (option)
    {
        case "1":
            Console.WriteLine("Add a person");
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";

            Console.Write("Age: ");
            var age = int.Parse(Console.ReadLine() ?? "0");

            _controller.Create(name, age);
            _controller.Print("\nPerson added successfully.\n", ConsoleColor.Green);
            break;

        case "2":
            var list = _controller.GetAll();
            view.Show(list);
            break;

        case "3":
            Console.Write("Person ID: ");
            var idUpdate = int.Parse(Console.ReadLine() ?? "0");

            if (_controller.Check(idUpdate))
            {
                Console.Write("New name: ");
                var newName = Console.ReadLine() ?? "";

                Console.Write("New age: ");
                var newAge = int.Parse(Console.ReadLine() ?? "0");

                _controller.Update(idUpdate, newName, newAge);
                _controller.Print("\nPerson updated successfully.\n", ConsoleColor.Green);
            }
            else
                _controller.Print("\nPerson not found.\n", ConsoleColor.Red);
            break;

        case "4":
            Console.Write("Person ID: ");
            var idDelete = int.Parse(Console.ReadLine() ?? "0");

            if (_controller.Delete(idDelete))
                _controller.Print("\nPerson removed successfully.\n", ConsoleColor.Green);
            else
                _controller.Print("\nPerson not found.\n", ConsoleColor.Red);
            break;

        case "0":
            _controller.Print("The program was terminated.\n", ConsoleColor.Red);
            return;

        default:
            _controller.Print("Invalid option.", ConsoleColor.Red);
            Console.WriteLine("\nPlease, try again.");
            break;
    }
}
