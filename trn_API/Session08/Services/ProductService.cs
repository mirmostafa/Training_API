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
        _logger.LogDebug("Creating a new product: " + product);
    }

    public Product? GetProductById(int id)
    {
        try
        {
            //****
            _logger.LogDebug("Connection to database");
            throw new Exception("Cannot connect to database");
            _logger.LogDebug("Connected to database");
            /////
        }
        catch (Exception ex)
        {
            _logger.LogError("Error while getting product by id: "+ ex.Message);
        }
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
