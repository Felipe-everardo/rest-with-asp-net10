using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestLogsController : ControllerBase
{
    private readonly ILogger<TestLogsController> _logger;
    public TestLogsController(ILogger<TestLogsController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult LogTest()
    {
        _logger.LogTrace("This is a trace log message.");
        _logger.LogDebug("This is a debug log message.");
        _logger.LogInformation("This is an informational log message.");
        _logger.LogWarning("This is a warning log message.");
        _logger.LogError("This is an error log message.");
        _logger.LogCritical("This is a critical log message.");
        
        return Ok("Log messages have been generated. Check your logging output.");
    }
}
