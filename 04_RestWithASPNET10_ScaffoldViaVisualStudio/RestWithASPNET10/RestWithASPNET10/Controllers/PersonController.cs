using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var person = _personService.FindById((int)id);
        if (person == null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        var createdPerson = _personService.Create(person);
        if (createdPerson == null) return NotFound();
        return Ok(createdPerson);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        var createdPerson = _personService.Update(person);
        if (createdPerson == null) return NotFound();
        return Ok(createdPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}