#nullable disable

using Microsoft.EntityFrameworkCore;

using Session07.DbContexts;
using Session07.Models;

namespace Session07.SampleCodes;

public class FilteringAndPagination
{
    private readonly ApplicationDbContext _context = new(null);

    public async Task<List<Product>> GetProducts(int page, int pageSize)
    {
        var query = this._context.Products
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        var dbResult = await query.ToListAsync();
        return dbResult;
    }

    public async Task<List<Product>> GetProductsByName(string name)
    {
        var query = this._context.Products
            .Where(p => p.Name.Contains(name));
        var dbResult = await query.ToListAsync();
        return dbResult;
    }
}