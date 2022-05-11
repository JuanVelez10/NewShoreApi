using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyServices journeyServices;

        public JourneyController(IJourneyServices journeyServices)
        {
            this.journeyServices = journeyServices;
        }

        // POST api/<JourneyController>/origin/destination/route
        [HttpGet("{origin}/{destination}/{route}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(string origin,string destination,int route)
        {
            var result = await journeyServices.Get(origin, destination, route);
            if (result != null) return Ok(result);
            return NotFound(result);
        }

    }
}
