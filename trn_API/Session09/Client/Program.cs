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
    else
    {
        foreach (var product in products)
        {
            Display(product);
        }
    }
}

// Method to add product using product controller
static async Task TestAddProduct()
{
    var pen = new Product
    {
        Name = "خودکار",
        Price = -5
    };

    using var client = new HttpClient();
    var request = new HttpRequestMessage();
    request.Method = HttpMethod.Post;
    request.RequestUri = new Uri("http://localhost:5198/Product");
    request.Content = new StringContent(JsonConvert.SerializeObject(pen), Encoding.UTF8, "application/json");
    
    using var response = await client.SendAsync(request);
    string body = string.Empty;
    try
    {
        body = await response.Content.ReadAsStringAsync();
        response.EnsureSuccessStatusCode();
        var product = JsonConvert.DeserializeObject<Product>(body);
    }
    catch
    {
        Console.WriteLine(body);
    }
    
    
    
    //Display(product!);
}

static void Display(Product product)
{
    Console.WriteLine($"Id: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine();
}
