using Session12.Domain.Dtos;

namespace Session12.Application.Services;


public class ProductService : IProductService
{
    private readonly List<Product> _products =
    [
        new Product { Id = 1, Name = "Laptop", Price = 1500 },
        new Product { Id = 2, Name = "Phone", Price = 800 },
        new Product { Id = 3, Name = "Tablet", Price = 600 }
    ];

    public List<Product> GetAll() => 
        _products;

    public Product? GetById(int id) => 
        _products.FirstOrDefault(p => p.Id == id);

    public int Add(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        return product.Id;
    }
}
