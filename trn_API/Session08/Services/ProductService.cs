using Session08.Model;

namespace Session08.Services;

public class ProductService
{
    private readonly ILogger<ProductService> _logger;

    public ProductService(ILogger<ProductService> logger)
    {
        _logger = logger;
    }

    public void CreateProduct(Product product)
    {
        _logger.LogDebug("Creating a new product: {@Product}", product);
    }

    public Product? GetProductById(int id)
    {
        _logger.LogWarning("Fetching product with ID: {Id}", id);
        return null; // No real operation
    }

    public void UpdateProduct(Product product)
    {
        _logger.LogInformation("Updating product: {@Product}", product);
    }

    public void DeleteProduct(int id)
    {
        _logger.LogInformation("Deleting product with ID: {Id}", id);
    }
}
