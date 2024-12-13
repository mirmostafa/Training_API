using Microsoft.AspNetCore.Mvc;

using Session08.Model;
using Session08.Services;

namespace Session08.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _service.CreateProduct(product);
        return Ok("Product created.");
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = _service.GetProductById(id);
        return Ok(product);
    }

    [HttpPut]
    public IActionResult Update(Product product)
    {
        _service.UpdateProduct(product);
        return Ok("Product updated.");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.DeleteProduct(id);
        return Ok("Product deleted.");
    }
}
