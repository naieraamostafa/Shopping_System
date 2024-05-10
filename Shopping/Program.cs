
namespace Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            string name, email;
            int maxItems;

            Console.WriteLine("Please input your details:");
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your E-mail: ");
            email = Console.ReadLine();
            Console.Write("Enter the max number of items: ");
            while (!int.TryParse(Console.ReadLine(), out maxItems) || maxItems <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer for max items:");
            }

            Seller seller = new Seller(name, email, maxItems);

            int choice = 0;
            while (choice != 6)
            {
                Console.WriteLine("\nChoose:");
                Console.WriteLine("1. Print My Details");
                Console.WriteLine("2. Add an Item");
                Console.WriteLine("3. Sell an Item");
                Console.WriteLine("4. Print Items");
                Console.WriteLine("5. Find an Item by ID");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid choice. Enter a number between 1 and 6:");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n" + seller);
                        break;
                    case 2:
                        Item item = new Item();
                        Console.WriteLine();
                        Console.WriteLine("Enter item details:");
                        Console.Write("Enter ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
                        {
                            Console.WriteLine("Invalid input. Enter a valid integer for ID:");
                            Console.Write("Enter ID: ");
                        }
                        item.ID = id;

                        Console.Write("Enter Name: ");
                        item.Name = Console.ReadLine();

                        Console.Write("Enter Quantity: ");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Invalid input. Enter a non-negative integer for Quantity:");
                            Console.Write("Enter Quantity: ");
                        }
                        item.Quantity = quantity;

                        Console.Write("Enter Price: ");
                        double price;
                        while (!double.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.WriteLine("Invalid input. Enter a non-negative number for Price:");
                            Console.Write("Enter Price: ");
                        }
                        item.Price = price;

                        seller.AddItem(item);
                        break;

                    case 3:
                        string itemName;                       
                        Console.Write("\nEnter the name of item: ");
                        itemName = Console.ReadLine();
                        Console.Write("Enter the quantity of item to be sold: ");
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
                        {
                            Console.WriteLine("Invalid input. Enter a non-negative integer for Quantity:");
                        }
                        if (!seller.SellItem(itemName, quantity))
                            Console.WriteLine("Item not found or insufficient quantity available.");
                        break;
                    case 4:
                        Console.WriteLine();
                        seller.PrintItems();
                        break;
                    case 5:
                        Console.Write("\nEnter the ID of item to be found: ");
                        while (!int.TryParse(Console.ReadLine(), out id) || id < 0)
                        {
                            Console.WriteLine("Invalid input. Enter a non-negative integer for ID:");
                        }
                        Item foundItem = seller.FindById(id);
                        if (foundItem == null)
                            Console.WriteLine("Item not found!");
                        else
                            Console.WriteLine("Item found:\n" + foundItem);
                        break;
                    case 6:
                        break;
                }
            }
        }
    }
}
