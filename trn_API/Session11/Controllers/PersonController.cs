using Microsoft.AspNetCore.Mvc;

namespace Session11.Controllers;

public sealed class PersonController:ControllerBase
{
    [HttpGet]
    public Task<IActionResult> GetAll()
    {
        return Task.FromResult((IActionResult)default);
    }

    [HttpGet("{id:long")]
    public Task<IActionResult> GetById(long id)
    {
        return Task.FromResult((IActionResult)default);
    }

    [HttpPost]
    public Task<IActionResult> Insert(Person person)
    {
        return Task.FromResult((IActionResult)default);
    }

    [HttpPut("{id:long")]
    public Task<IActionResult> Update(long id, Person person)
    {
        return Task.FromResult((IActionResult)default);
    }

    [HttpDelete("{id:long")]
    public Task<IActionResult> Delete(long id)
    {
        return Task.FromResult((IActionResult)default);
    }
}

public sealed class Person
{
    public long Id { get; set; }
}
