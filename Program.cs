using HW11.configuration;
using HW11.Interfaces;
using HW11.Repostitories;
using HW11.Services;
using ConsoleTables;
using ColoredConsole;




var connectionString = Configuration.ConnectionString;

var productRepository = new ProductRepository(connectionString);
var categoryRepository = new CategoryRepository(connectionString);

IProductService _productService = new ProductService(productRepository, categoryRepository);

while (true)
{
    Console.Clear();
    ColorConsole.WriteLine("Choose an operation:".DarkGreen());
    Console.WriteLine("1. Add Product");
    Console.WriteLine("2. Display All Products");
    Console.WriteLine("3. Get Product by ID");
    Console.WriteLine("4. Update Product");
    Console.WriteLine("5. Delete Product");
    ColorConsole.WriteLine("6. Exit".DarkRed());

    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            ColorConsole.Write("Enter product name: ".DarkYellow());
            var name = Console.ReadLine();
            ColorConsole.Write("Enter product price: ".DarkYellow());
            var price = decimal.Parse(Console.ReadLine());

            ColorConsole.WriteLine("Select a category:".DarkYellow());
            var categories = _productService.GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }
            var categoryId = int.Parse(Console.ReadLine());

            _productService.AddProduct(name, price, categoryId);
            Console.WriteLine("Product added successfully.".DarkGreen());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "2":
            var products = _productService.GetAllProducts();
            if (products.Any())
            {
                var table = new ConsoleTable("ID", "Name", "Price", "Category");
                foreach (var product in products)
                {
                    table.AddRow(product.Id, product.Name, product.Price, categoryRepository.GetByID(product.CategoryId));
                }
                table.Write();
            }
            else
            {
                ColorConsole.WriteLine("No products available.".DarkRed());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "3":
            ColorConsole.Write("Enter product ID: ".DarkYellow());
            var id = int.Parse(Console.ReadLine());
            var productById = _productService.GetProductById(id);

            if (productById != null)
            {
                var table = new ConsoleTable("ID", "Name", "Price", "Category");
                table.AddRow(productById.Id, productById.Name, productById.Price, productById.Name);
                table.Write();
            }
            else
            {
                ColorConsole.WriteLine("Product not found.".DarkRed());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "4":
            ColorConsole.Write("Enter product ID to update: ".DarkGreen());
            var updateId = int.Parse(Console.ReadLine());
            var productToUpdate = _productService.GetProductById(updateId);

            if (productToUpdate != null)
            {
                ColorConsole.Write("Enter new product name: ".DarkYellow());
                productToUpdate.Name = Console.ReadLine();
                ColorConsole.Write("Enter new product price: ".DarkYellow());
                productToUpdate.Price = decimal.Parse(Console.ReadLine());

                ColorConsole.WriteLine("Select a new category:".DarkGreen());
                var updateCategories = _productService.GetCategories();
                foreach (var category in updateCategories)
                {
                    Console.WriteLine($"{category.Id}. {category.Name}");
                }
                productToUpdate.CategoryId = int.Parse(Console.ReadLine());

                _productService.UpdateProduct(updateId, productToUpdate.Name, productToUpdate.Price, productToUpdate.CategoryId);
                ColorConsole.WriteLine("Product updated successfully.".DarkGreen());
            }
            else
            {
                ColorConsole.WriteLine("Product not found.".DarkRed());
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "5":
            ColorConsole.Write("Enter product ID to delete: ".DarkRed());
            var deleteId = int.Parse(Console.ReadLine());
            _productService.DeleteProduct(deleteId);
            ColorConsole.WriteLine("Product deleted successfully.".DarkRed());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;

        case "6":
            Console.WriteLine("Exiting...");
            return;

        default:
            ColorConsole.WriteLine("Invalid choice. Please try again.".DarkRed());
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            break;
    }
}
