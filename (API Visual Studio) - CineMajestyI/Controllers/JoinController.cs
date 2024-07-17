using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MoviesAPI.Models;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
	[ApiController]
	[Route("api/join")]
	public class JoinController : ControllerBase
	{
        private readonly AppDbContext _context;

        public JoinController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = _context.Bookings.Include(b => b.Customer).Include(b => b.Tickets).ThenInclude(t => t.Seatss)
                .ToList();
            Console.WriteLine(bookings);
            return Ok(bookings);
        }
    }
}

