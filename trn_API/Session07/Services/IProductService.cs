
using Session07.Models;

namespace Session07.Services;
public interface IProductService
{
    Task<Result> Delete(long id);
    Task<Result<List<Product>>> GetAll(int page = 0, int pageSize = 0);
    Task<Result<Product>> GetById(long id);
    Task<Result<long>> Insert(Product product);
    Task<Result> Update(long id, Product product);
}