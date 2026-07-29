using Microsoft.AspNetCore.Mvc;

namespace PartyNL.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "Healthy",
            service = "PartyNL API",
            version = "0.1.0"
        });
    }
}