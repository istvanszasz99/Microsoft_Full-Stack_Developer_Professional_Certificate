using System;
using System.Collections.Generic;

namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(string name, decimal price, int quantity)
        {
            products.Add(new Product(name, price, quantity));
        }

        public bool UpdateStock(int index, int quantityChange)
        {
            if (index < 0 || index >= products.Count)
                return false;
            int newQty = products[index].Quantity + quantityChange;
            if (newQty < 0)
                return false;
            products[index].Quantity = newQty;
            return true;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public bool RemoveProduct(int index)
        {
            if (index < 0 || index >= products.Count)
                return false;
            products.RemoveAt(index);
            return true;
        }
    }
}
