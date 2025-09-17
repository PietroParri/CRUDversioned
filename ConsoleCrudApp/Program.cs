using ConsoleCrudApp.Controllers;
using ConsoleCrudApp.Views;

var controller = new PersonController();
var view = new PersonView();

Console.WriteLine("CRUDversioned v.1.0 (17/09/2025)");
Console.WriteLine("Made by Pietro Borges Parri\n");

while (true)
{
    Console.WriteLine("\nOptions:");
    Console.WriteLine("1 - Add Person");
    Console.WriteLine("2 - List People");
    Console.WriteLine("3 - Update Person");
    Console.WriteLine("4 - Remove Person");
    Console.WriteLine("0 - Exit");
    Console.Write("Choose an option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Age: ");
            var age = int.Parse(Console.ReadLine() ?? "0");
            controller.Create(name, age);
            break;

        case "2":
            var list = controller.GetAll();
            view.Show(list);
            break;

        case "3":
            Console.Write("Person ID: ");
            var idUpdate = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("New name: ");
            var newName = Console.ReadLine() ?? "";
            Console.Write("New age: ");
            var newAge = int.Parse(Console.ReadLine() ?? "0");
            if (controller.Update(idUpdate, newName, newAge))
                Console.WriteLine("Person updated successfully.");
            else
                Console.WriteLine("Person not found.");
            break;

        case "4":
            Console.Write("Person ID: ");
            var idDelete = int.Parse(Console.ReadLine() ?? "0");
            if (controller.Delete(idDelete))
                Console.WriteLine("Person removed successfully.");
            else
                Console.WriteLine("Person not found.");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}
