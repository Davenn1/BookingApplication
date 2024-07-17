using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class UserLogin
    {
        [Required]
        public string Customer_Email { get; set; }
        [Required]
        public string Customer_Password { get; set; }

    }
}
