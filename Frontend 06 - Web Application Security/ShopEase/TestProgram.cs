using System;
using ShopEase;

namespace ShopEase
{
    public class TestProgram
    {
        public static void Main(string[] args)
        {
            var product1 = new Product(1, "Laptop", 999.99m, "Electronics");
            var product2 = new Product(2, "Headphones", 199.99m, "Electronics");
            var cart = new Cart();

            cart.AddProduct(product1);
            cart.AddProduct(product2);
            cart.RemoveProduct(1);

            Console.WriteLine("Cart Contents:");
            cart.DisplayCartItems();
            Console.WriteLine($"Total: ${cart.CalculateTotal():F2}");
        }
    }
}
