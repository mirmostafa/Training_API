using Application.DataSources;

using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;
public class ProductRepository(ApplicationDbContext writeDbContext)
{
    private readonly ApplicationDbContext _writeDbContext = writeDbContext;

    public async Task<Product> InsertProduct(Product product, CancellationToken cancellationToken)
    {
        _ = await this._writeDbContext.Products.AddAsync(product, cancellationToken);
        _ = await this._writeDbContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<int> UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        this._writeDbContext.Products.Update(product);
        return await this._writeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteProduct(Product product, CancellationToken cancellationToken)
    {
        this._writeDbContext.Products.Remove(product);
        return await this._writeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product?> GetProductById(long id, CancellationToken cancellationToken)
    {
        return await this._writeDbContext.Products.FindAsync([id], cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetProducts(CancellationToken cancellationToken)
    {
        return await this._writeDbContext.Products.ToListAsync(cancellationToken: cancellationToken);
    }
}
