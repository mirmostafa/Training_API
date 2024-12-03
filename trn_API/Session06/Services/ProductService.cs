using Microsoft.EntityFrameworkCore;

using Session06.DataSources;

namespace Session06.Services;

public class ProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        this._context = context;
    }

    public async Task Delete(int id)
    {
        var product = await this._context.Products.FindAsync(id);
        if (product != null)
        {
            _ = this._context.Products.Remove(product);
            _ = await this._context.SaveChangesAsync();
        }
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await this._context.Products.ToListAsync();
    }

    public List<Product> GetAll()
    {
        return this._context.Products.ToList();
    }

    public async Task<Product?> GetById(int id)
    {
        return await this._context.Products.FindAsync(id);
    }

    public async Task Insert(Product product)
    {
        _ = await this._context.Products.AddAsync(product);
        _ = await this._context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _ = this._context.Products.Update(product);
        _ = await this._context.SaveChangesAsync();
    }
}
