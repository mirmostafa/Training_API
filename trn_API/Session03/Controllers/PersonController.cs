using Microsoft.AspNetCore.Mvc;

using Session03.Models;

namespace Session03.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    public PersonController()
    {

    }
    // Sample in-memory data storage
    static IList<Person> _people = new List<Person>();

    // Create (POST): Add a new person
    [HttpPost]
    public IActionResult Create(Person person)
    {
        person.Id = _people.Count + 1; // Simple ID generation
        _people.Add(person);
        return Ok(person.Id);
    }

    // Read (GET): Get all people
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_people);
    }

    // Read (GET): Get a person by ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            return NotFound();
        }
        return Ok(person);
    }

    // Update (PUT): Update a person by ID
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Person updatedPerson)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            return NotFound();
        }
        person.Name = updatedPerson.Name;
        person.Age = updatedPerson.Age;
        return Ok();
    }

    // Delete (DELETE): Delete a person by ID
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            return NotFound();
        }
        _people.Remove(person);
        return Ok();
    }
}