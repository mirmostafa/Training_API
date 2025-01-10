using System.Text;

using Domain.Models;

using Newtonsoft.Json;

Console.WriteLine("Client is ready.");
Console.ReadLine();

await TestAddProduct();
await TestGetAllAsync();

Console.ReadLine();

static async Task TestGetAllAsync()
{
    using var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri("http://localhost:5198/Product"),
    };
    using var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();

    var products = JsonConvert.DeserializeObject<List<Product>>(body);
    if (products?.Any() is not true)
    {
        Console.WriteLine("No product found.");
    }

    else foreach (var product in products)
        {
            Display(product);
        }
}

// Method to add product using product controller
static async Task TestAddProduct()
{
    var pen = new Product
    {
        Name = "Pen",
        Price = 100
    };

    using var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Post,
        RequestUri = new Uri("http://localhost:5198/Product"),
        Content = new StringContent(JsonConvert.SerializeObject(pen), Encoding.UTF8, "application/json")
    };
    using var response = await client.SendAsync(request);
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    
    var product = JsonConvert.DeserializeObject<Product>(body);
    Display(product!);
}

static void Display(Product product)
{
    Console.WriteLine($"Id: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine();
}
