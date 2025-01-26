using Application.DataSources;
using Application.Repositories;

using Domain;
using Domain.Models;

namespace Application.Services;
public sealed class ProductService(ProductRepository repository)
{
    private readonly ProductRepository repository = repository;

    public async Task<Result<Product>> AddProduct(Product product, CancellationToken cancellationToken)
    {
        try
        {
            if(product.Price <= 0)
            {
                throw new Exception("Price must be bigger than 0.");
            }
            var dbResult = await repository.InsertProduct(product, cancellationToken);
            return Result<Product>.Success(dbResult);
        }
        catch (Exception ex)
        {
            return Result<Product>.Fail(ex.GetBaseException().Message);
        }
    }

    public async Task<Result<Product?>> GetProductById(int id, CancellationToken cancellationToken)
    {
        try
        {
            var dbResult = await repository.GetProductById(id, cancellationToken);
            return Result<Product?>.Success(dbResult);
        }
        catch (Exception ex)
        {
            return Result<Product?>.Fail(ex.GetBaseException().Message);
        }
    }

    public async Task<Result<IEnumerable<Product>>> GetProducts(CancellationToken cancellationToken)
    {
        try
        {
            var dbResult = await repository.GetProducts(cancellationToken);
            return Result<IEnumerable<Product>>.Success(dbResult);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Product>>.Fail(ex.GetBaseException().Message);
        }
    }

    public async Task<Result<Product>> UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        try
        {
            var affectedRowsCount = await repository.UpdateProduct(product, cancellationToken);
            return Result<Product>.Success(product);
        }
        catch (Exception ex)
        {
            return Result<Product>.Fail(ex.GetBaseException().Message);
        }
    }

    public async Task<Result> DeleteProduct(long id, CancellationToken cancellationToken)
    {
        try
        {
            var product = await repository.GetProductById(id, cancellationToken);
            if (product is null)
            {
                throw new Exception("Product not found");
            }
            var affectedRowsCount = await repository.DeleteProduct(product, cancellationToken);
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Fail(ex.GetBaseException().Message);
        }
    }
}
