using System;
using InventoryManagementSystem;

class Program
{
    static InventoryManager inventory = new InventoryManager();

    static void Main(string[] args)
    {
        while (true)
        {
            ShowMenu();
            string? choice = Console.ReadLine();
            if (choice == null) choice = string.Empty;
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    ViewProducts();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n--- Inventory Management System ---");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. Update Stock");
        Console.WriteLine("3. View Products");
        Console.WriteLine("4. Remove Product");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }

    static void AddProduct()
    {
        Console.Write("Enter product name: ");
        string? name = Console.ReadLine();
        if (name == null) name = string.Empty;
        decimal price;
        int quantity;
        while (true)
        {
            Console.Write("Enter price: ");
            string? priceInput = Console.ReadLine();
            if (priceInput == null) priceInput = string.Empty;
            if (decimal.TryParse(priceInput, out price) && price >= 0)
                break;
            Console.WriteLine("Invalid price. Try again.");
        }
        while (true)
        {
            Console.Write("Enter quantity: ");
            string? qtyInput = Console.ReadLine();
            if (qtyInput == null) qtyInput = string.Empty;
            if (int.TryParse(qtyInput, out quantity) && quantity >= 0)
                break;
            Console.WriteLine("Invalid quantity. Try again.");
        }
        inventory.AddProduct(name, price, quantity);
        Console.WriteLine("Product added successfully!");
    }

    static void UpdateStock()
    {
        var products = inventory.GetProducts();
        if (products.Count == 0)
        {
            Console.WriteLine("No products to update.");
            return;
        }
        ViewProducts();
        int index;
        while (true)
        {
            Console.Write("Select product number to update: ");
            string? idxInput = Console.ReadLine();
            if (idxInput == null) idxInput = string.Empty;
            if (int.TryParse(idxInput, out index) && index > 0 && index <= products.Count)
                break;
            Console.WriteLine("Invalid selection. Try again.");
        }
        int qtyChange;
        while (true)
        {
            Console.Write("Enter quantity to add (positive) or subtract (negative): ");
            string? qtyInput = Console.ReadLine();
            if (qtyInput == null) qtyInput = string.Empty;
            if (int.TryParse(qtyInput, out qtyChange))
                break;
            Console.WriteLine("Invalid input. Try again.");
        }
        if (inventory.UpdateStock(index - 1, qtyChange))
            Console.WriteLine("Stock updated successfully!");
        else
            Console.WriteLine("Update failed. Check quantity.");
    }

    static void ViewProducts()
    {
        var products = inventory.GetProducts();
        if (products.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
            return;
        }
        Console.WriteLine("\n--- Product List ---");
        for (int i = 0; i < products.Count; i++)
        {
            var p = products[i];
            Console.WriteLine($"{i + 1}. Name: {p.Name}, Price: {p.Price:C}, Quantity: {p.Quantity}");
        }
    }

    static void RemoveProduct()
    {
        var products = inventory.GetProducts();
        if (products.Count == 0)
        {
            Console.WriteLine("No products to remove.");
            return;
        }
        ViewProducts();
        int index;
        while (true)
        {
            Console.Write("Select product number to remove: ");
            string? idxInput = Console.ReadLine();
            if (idxInput == null) idxInput = string.Empty;
            if (int.TryParse(idxInput, out index) && index > 0 && index <= products.Count)
                break;
            Console.WriteLine("Invalid selection. Try again.");
        }
        Console.Write($"Are you sure you want to remove '{products[index - 1].Name}'? (y/n): ");
        string? confirm = Console.ReadLine();
        if (confirm == null) confirm = string.Empty;
        if (confirm.ToLower() == "y")
        {
            inventory.RemoveProduct(index - 1);
            Console.WriteLine("Product removed.");
        }
        else
        {
            Console.WriteLine("Remove cancelled.");
        }
    }
}
