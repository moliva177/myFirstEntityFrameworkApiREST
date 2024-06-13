using Microsoft.AspNetCore.Mvc;
using PrimerApi.Data;
using PrimerApi.Interfaces.Services;

namespace PrimerApi.Controllers
{
    [ApiController]
    public class AvionController : ControllerBase
    {
        private readonly IAvionService _avionService;

        public AvionController(IAvionService avionService)
        {
            _avionService = avionService;
        }

        [HttpGet("aviones/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var aviones = await _avionService.GetAll();
            return Ok(aviones);
        }
    }
}
