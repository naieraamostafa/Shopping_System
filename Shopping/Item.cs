using System;

namespace Shopping
{
    internal class Item
    {
        //Setters and getters
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        // Default constructor
        public Item()
        {
            ID = 0;
            Name = "";
            Quantity = 0;
            Price = 0.0;
        }

        // Parameterized constructor
        public Item(int id, string name, int quantity, double price)
        {
            ID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        // Copy constructor
        public Item(Item item)
        {
            ID = item.ID;
            Name = item.Name;
            Quantity = item.Quantity;
            Price = item.Price;
        }

        // Equals method
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Name == ((Item)obj).Name;
        }

        //GetHashCode method
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        //ToString method
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Quantity: {Quantity}, Price: {Price}";
        }

        // Addition operator
        public static Item operator +(Item item1, Item item2)
        {
            item1.Quantity += item2.Quantity;
            return item1;
        }

        // Subtraction operator
        public static Item operator -(Item item, int soldQuantity)
        {
            if (item.Quantity >= soldQuantity)
            {
                item.Quantity -= soldQuantity;
            }
            else
            {
                Console.WriteLine("Insufficient quantity available.");
            }
            return item;
        }
    }
}
