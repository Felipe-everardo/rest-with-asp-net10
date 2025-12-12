using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    public readonly IBookServices _bookServices;
    public readonly ILogger<BookController> _logger;

    public BookController(IBookServices bookServices, ILogger<BookController> logger)
    {
        _bookServices = bookServices;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Fetching all books");
        return Ok(_bookServices.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        _logger.LogInformation($"Fetching book with id: {id}");
        var book = _bookServices.FindById(id);
        if (book == null) 
        {
            _logger.LogWarning($"Book with id: {id} not found");
            return NotFound();
        }
        _logger.LogInformation($"Book found: {book.Title}");
        return Ok(book);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Book book)
    {
        if (book == null) 
        {
            _logger.LogWarning("Received null book object in POST request");
            return BadRequest();
        }
        _logger.LogInformation($"Creating new book: {book.Title}");
        return Ok(_bookServices.Create(book));
    }

    [HttpPut]
    public IActionResult Put([FromBody] Book book)
    {
        if (book == null)
        {
            _logger.LogWarning("Received null book object in PUT request");
            return BadRequest();
        }

        var updatedBook = _bookServices.Update(book);
        if (updatedBook == null) 
        {
            _logger.LogWarning($"Book with id: {book.Id} not found for update");
            return NotFound();
        }
        
        _logger.LogInformation($"Updated book: {updatedBook.Title}");
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _logger.LogInformation($"Deleting book with id: {id}");
        _bookServices.Delete(id);
        return NoContent();
    }
}
