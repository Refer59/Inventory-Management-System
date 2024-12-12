using InventoryManagementSystem.Services;



var manager = new InventoryManager();
while (true)
{
    Console.WriteLine("\nInventory Management System");
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Update Stock");
    Console.WriteLine("3. View Products");
    Console.WriteLine("4. Remove Product");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price.");
                break;
            }
            Console.Write("Enter stock quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var stock))
            {
                Console.WriteLine("Invalid stock quantity.");
                break;
            }
            manager.AddProduct(name, price, stock);
            break;

        case "2":
            Console.Write("Enter product name to update stock: ");
            string updateName = Console.ReadLine();
            Console.Write("Enter stock change (positive to add, negative to reduce): ");
            if (!int.TryParse(Console.ReadLine(), out var stockChange))
            {
                Console.WriteLine("Invalid stock change.");
                break;
            }
            manager.UpdateStock(updateName, stockChange);
            break;

        case "3":
            manager.ViewProducts();
            break;

        case "4":
            Console.Write("Enter product name to remove: ");
            string removeName = Console.ReadLine();
            manager.RemoveProduct(removeName);
            break;

        case "5":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}