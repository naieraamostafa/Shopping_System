

namespace Shopping
{

    internal class Seller
    {
        //Setters and getters
        public string Name { get; set; }
        public string Email { get; set; }
        public int MaxItems { get; set; }
        private List<Item> items;

        // Parameterized constructor
        public Seller(string name, string email, int maxItems)
        {
            Name = name;
            Email = email;
            MaxItems = maxItems;
            items = new List<Item>();
        }

        public bool AddItem(Item newItem)
        {
            if (items.Count >= MaxItems)
            {
                Console.WriteLine("Seller's item limit reached. Cannot add more items.");
                return false;
            }

            bool itemExists = false;
            foreach (Item item in items)
            {
                if (item.Equals(newItem))
                {
                    item.Quantity += newItem.Quantity; // Increase the quantity
                    itemExists = true;
                    break;
                }
            }

            if (!itemExists)
            {
                items.Add(newItem);
            }

            return true;
        }

        public bool SellItem(string itemName, int quantity)
        {
            bool itemFound = false;
            foreach (Item item in items)
            {
                if (item.Name == itemName)
                {
                    itemFound = true;
                    if (item.Quantity >= quantity) // Check if enough quantity is available
                    {
                        item.Quantity -= quantity; // Decrease the quantity
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient quantity available.");
                        return false;
                    }
                }
            }
            return false; // Item not found
        }

        public void PrintItems()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }
        }

        public Item FindById(int id)
        {
            foreach (Item item in items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null; // Item not found
        }

        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Max Items: {MaxItems}";
        }
    }
}
