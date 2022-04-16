// See https://aka.ms/new-console-template for more information
using E01.Objects;

Console.WriteLine("Hello, World!");
List<Product> products = new List<Product>();
Product product = new Product();

for (int i = 0; i < 100; i++)
{
    product.Id = i;
    product.Name = "Product -" + i;

    products.Add(product); 
}

products.ForEach(p =>
{
    global::System.Console.WriteLine(p.Name);
});

