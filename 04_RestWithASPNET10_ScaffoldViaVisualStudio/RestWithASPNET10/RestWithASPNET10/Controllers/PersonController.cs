using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private IPersonServices _personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonServices personService,
        ILogger<PersonController> logger)
    {
        _personService = personService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Fetching all persons");
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation("Fetching persons with ID {id}", id);
        var person = _personService.FindById(id);
        if (person == null)
        {
            _logger.LogWarning("Person with ID {id} not found", id);
            return NotFound();
        }
        return Ok(person);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        _logger.LogInformation("Creating new persons: {firstName}", person.FirstName);
        var createdPerson = _personService.Create(person);
        if (createdPerson == null)
        {
            _logger.LogWarning("Failed to create person: {firstName}", person.FirstName);
            return NotFound();
        }
        return Ok(createdPerson);
    }

    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        _logger.LogInformation("Updateing persons with ID {id}", person.Id);
        var createdPerson = _personService.Update(person);
        if (createdPerson == null)
        {
            _logger.LogWarning("Person with ID {id} not found for update", person.Id);
            return NotFound();
        }
        _logger.LogDebug("Person with ID {id} updated successfully", person.Id);
        return Ok(createdPerson);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _logger.LogInformation("Delete persons with ID {id}", id);
        _personService.Delete(id);
        _logger.LogDebug("Person with ID {id} deleted successfully", id);
        return NoContent();
    }
}