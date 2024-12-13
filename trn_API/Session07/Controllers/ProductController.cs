using Microsoft.AspNetCore.Mvc;

using Session07.Models;
using Session07.Services;

namespace Session07.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    private readonly IProductService _service = service;

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var result = await this._service.Insert(product);
        return result.IsSuccess ? this.Ok(result) : this.BadRequest(result);
    }
    
    [HttpGet]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll(int page = 0, int pageSize = 0)
    {
        var result = await this._service.GetAll(page, pageSize);
        return result.IsSuccess ? this.Ok(result) : this.BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var result = await this._service.GetById(id);
        return result.IsSuccess 
            ? this.Ok(result) 
            : result.Data is null 
                ? this.NotFound(result) 
                : this.BadRequest(result);
    }
}
