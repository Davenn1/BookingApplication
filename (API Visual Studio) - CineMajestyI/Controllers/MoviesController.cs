using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using MoviesAPI.Data;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{Room_ID}")]

        public List<Seats> Get(int Room_ID)
        {
            var SeatList = _context.Seats.Where(x=>x.Room_ID==Room_ID).Select(x => new Seats
            {
                Seats_ID = x.Seats_ID,
                Ticket_ID = x.Ticket_ID,
                Room_ID = x.Room_ID,
                Seat_Number = x.Seat_Number,
                Seat_IsAvailable = x.Seat_IsAvailable
            });

            return SeatList.ToList();
        }

        [HttpPut("{seat_number}")]

        public async Task<ActionResult>  setSeat(int seatNumber, [FromBody] UpdateSeatRequest value)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_context.Seats.Any(x=>x.Seat_Number == seatNumber))
            {
                return NotFound("Seat not found");
            }

            var seat = await _context.Seats.FirstOrDefaultAsync(x => x.Seat_Number == seatNumber);
            seat.Seat_Number = value.Seat_Number;
            seat.Room_ID = value.Room_ID;
            seat.Ticket_ID = value.Ticket_ID;
            seat.Seat_IsAvailable = value.Seat_IsAvailable;
            seat.Seats_ID = value.Seats_ID;

            await (_context.SaveChangesAsync());

            return Ok();
        }

        [HttpPost("Booking")]

        public ActionResult setBooking([FromBody] setBookingRequest books)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            };

            var count = _context.Bookings.Select(x => new Booking
            {
                //Booking_ID = x.Booking_ID,
                Customer_ID = x.Customer_ID,
                Movie_ID = x.Movie_ID
            }).ToList().Count();
            var book = new Booking
            {
                //Booking_ID = count + 1,
                Customer_ID = books.Customer_ID,
                Movie_ID = books.Movie_ID
            };
            Console.WriteLine(book);
            _context.Bookings.Add(book);
            _context.SaveChanges();
            return Ok();
            
                
        }
    }
}
