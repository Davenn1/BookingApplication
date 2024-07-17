using MoviesAPI.Data;
using MoviesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;
        public DataController(DataContext context) {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegister request) {
            if (_context.Customer.Any(u => u.Customer_Email == request.Customer_Email)) {
                return StatusCode(400, "User already exists");
            }
            var count = _context.Customer.Select(x => new Customer
            {
                Customer_ID = x.Customer_ID,
                Customer_Email = x.Customer_Email,
                Customer_Name = x.Customer_Name,
                Customer_Password = x.Customer_Password,
            }).ToList().Count();
            var user = new Customer
            {
                Customer_ID = count + 1,
                Customer_Email = request.Customer_Email,
                Customer_Name = request.Customer_Name,
                Customer_Password = request.Customer_Password,
            };
            _context.Customer.Add(user);
            await _context.SaveChangesAsync();
            return StatusCode(200, user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> MoviesAPI(UserLogin request) {
            var user = await _context.Customer.FirstOrDefaultAsync(u => u.Customer_Email == request.Customer_Email);
            if (user == null) {
                return StatusCode(400, "User not found");
            }

            if (!verifypassword(request.Customer_Password, user.Customer_Password)) {
                return StatusCode(400, "password incorect");
            }
            return StatusCode(200, user);
        }


        private bool verifypassword(string password, string pass2) {

            return password.Equals(pass2);
        }
    }
}
