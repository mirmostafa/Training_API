using Application.DataSources;
using Application.Services;

using Domain;
using Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ProductService service) : ControllerBase
{
    private readonly ProductService _service = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts(CancellationToken cancellationToken)
    {
        var result = await _service.GetProducts(cancellationToken);
        if (result.IsSucceed)
            return Ok(result.Value);
        else
            return BadRequest(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductById(int id, CancellationToken cancellationToken)
    {
        var result = await _service.GetProductById(id, cancellationToken);
        if (result.IsSucceed)
            return Ok(result.Value);
        else
            return BadRequest(result.Message);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProduct(Product product, CancellationToken cancellationToken)
    {
        var result = await _service.AddProduct(product, cancellationToken);
        if (result.IsSucceed)
            return Ok(result.Value);
        else
            return BadRequest(result.Message);
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateProduct(product, cancellationToken);
        if (result.IsSucceed)
            return Ok(result.Value);
        else
            return BadRequest(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result>> DeleteProduct(long id, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteProduct(id, cancellationToken);
        if (result.IsSucceed)
            return Ok();
        else
            return BadRequest(result.Message);
    }
}
