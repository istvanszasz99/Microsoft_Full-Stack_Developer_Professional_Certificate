using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace ShopEase
{
    public class Cart
    {
        private List<Product> products = new List<Product>();
        private string connectionString = "server=localhost;user=root;database=Shop;port=3306;password=yourpassword";

        public void AddProduct(Product product)
        {
            products.Add(product);
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO Products (ProductID, Name, Price, Category) VALUES (@id, @name, @price, @category)", conn);
                cmd.Parameters.AddWithValue("@id", product.ProductID);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@category", product.Category);
                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveProduct(int productId)
        {
            products.RemoveAll(p => p.ProductID == productId);
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM Products WHERE ProductID = @id", conn);
                cmd.Parameters.AddWithValue("@id", productId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DisplayCartItems()
        {
            foreach (var product in products)
            {
                product.PrintDetails();
            }
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var product in products)
            {
                total += product.Price;
            }
            return total;
        }
    }
}
