using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Session12.Application.Services;
using Session12.Domain.Dtos;

namespace Session12.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product)
    {
        var id = this._productService.Add(product);
        return this.CreatedAtAction(nameof(GetProductById), new { id }, id);
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = this._productService.GetById(id);
        return product == null ? this.NotFound() : this.Ok(product);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetProducts() =>
        this.Ok(this._productService.GetAll());
}