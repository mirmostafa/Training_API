using System;

using Microsoft.AspNetCore.Mvc;
using Session06.DataSources;
using Session06.Services;

namespace Session06.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _service;

    public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAllProducts();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _service.Insert(product);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id,  Product product)
    {
        product.Id = id;
        await _service.Update(product);
        return Ok();
    }
}
