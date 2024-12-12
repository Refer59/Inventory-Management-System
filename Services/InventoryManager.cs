
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class InventoryManager
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name) || price < 0 || stock < 0)
            {
                Console.WriteLine("Invalid product details.");
                return;
            }

            _products.Add(new Product(name, price, stock));
            Console.WriteLine("Product added successfully.");
        }

        public void UpdateStock(string name, int stockChange)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            product.Stock += stockChange;
            if (product.Stock < 0)
            {
                product.Stock = 0;
                Console.WriteLine("Stock cannot be negative. Setting stock to 0.");
            }
            Console.WriteLine("Stock updated successfully.");
        }

        public void ViewProducts()
        {
            if (!_products.Any())
            {
                Console.WriteLine("No products in inventory.");
                return;
            }

            foreach (var product in _products)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}, Stock: {product.Stock}");
            }
        }

        public void RemoveProduct(string name)
        {
            var product = _products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            _products.Remove(product);
            Console.WriteLine("Product removed successfully.");
        }
    }
}