using System;

namespace ShopEase
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Product(int productId, string name, decimal price, string category)
        {
            ProductID = productId;
            Name = name;
            Price = price;
            Category = category;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Product: {Name} | Price: ${Price:F2} | Category: {Category}");
        }
    }
}
