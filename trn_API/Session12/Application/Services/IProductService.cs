using Session12.Domain.Dtos;

namespace Session12.Application.Services;

public interface IProductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    int Add(Product product);
}
