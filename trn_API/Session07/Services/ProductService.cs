using Microsoft.EntityFrameworkCore;

using Session07.DbContexts;
using Session07.Models;

namespace Session07.Services;

public sealed class ProductService(ApplicationDbContext dbContext) : IProductService
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<Result> Delete(long id)
    {
        try
        {
            var query = from p in this._dbContext.Products
                        where p.Id == id
                        select p;
            var dbResult = await query.FirstOrDefaultAsync();
            if (dbResult == null)
            {
                throw new Exception("Product not found.");
            }

            _ = this._dbContext.Remove(dbResult);
            _ = await this._dbContext.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    public async Task<Result<List<Product>>> GetAll(int page = 0, int pageSize = 0)
    {
        try
        {
            if (page > 0)
            {
                pageSize = 5;
            }

            var query = from product in this._dbContext.Products
                        select product;
            if (pageSize > 0)
            {
                query = query.Skip(pageSize * (page - 1)).Take(pageSize);
            }
            var dbResult = await query.ToListAsync();
            var result = Result<List<Product>>.Success(dbResult);
            return result;
        }
        catch (Exception ex)
        {
            return Result<List<Product>>.Failure(ex.Message);
        }
    }

    public async Task<Result<Product>> GetById(long id)
    {
        try
        {
            var query = from product in this._dbContext.Products
                        where product.Id == id
                        select product;
            var dbResult = await query.FirstOrDefaultAsync();
            if (dbResult == null)
            {
                throw new Exception("Product not found.");
            }
            var result = Result<Product>.Success(dbResult);
            return result;
        }
        catch (Exception ex)
        {
            return Result<Product>.Failure(ex.Message);
        }
    }

    public async Task<Result<long>> Insert(Product product)
    {
        try
        {
            if (product == null)
            {
                throw new NullReferenceException($"{nameof(product)} cannot be null or empty.");
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new NullReferenceException($"{nameof(product.Name)} cannot be null or empty.");
            }

            _ = this._dbContext.Products.Add(product);
            _ = await this._dbContext.SaveChangesAsync();

            return Result<long>.Success(product.Id);
        }
        catch (Exception ex)
        {
            return Result<long>.Failure(ex.Message);
        }
    }

    public async Task<Result> Update(long id, Product product)
    {
        try
        {
            var query = from p in this._dbContext.Products
                        where p.Id == product.Id
                        select p;
            var dbResult = await query.FirstOrDefaultAsync();
            if (dbResult == null)
            {
                return Result.Failure("Product not found.");
            }

            product.Name = dbResult.Name;
            _ = await this._dbContext.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}
