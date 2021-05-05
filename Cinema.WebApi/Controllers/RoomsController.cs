using Cinema.Persistence.DTO;
using Cinema.Persistence.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly ICinemaService _service;

        public RoomsController(ICinemaService service)
        {
            _service = service;
        }

        // GET: api/Rooms
        [HttpGet]
        public ActionResult<IEnumerable<RoomDto>> GetMovies()
        {
            return _service.GetRooms()
                .Select(room => (RoomDto)room)
                .ToList();
        }
    }
}
