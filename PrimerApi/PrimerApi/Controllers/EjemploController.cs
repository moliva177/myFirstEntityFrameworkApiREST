using Microsoft.AspNetCore.Mvc;

namespace PrimerApi.Controllers;

[ApiController]
public class EjemploController : ControllerBase
{
    public EjemploController()
    {
        
    }

    [HttpGet("GetExample")]
    public async Task<IActionResult> GetExample()
    {
        return Ok("Excelente! anda joya!!!");
    }
}