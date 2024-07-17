using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }
        [Required]
        [Column(TypeName = "Varchar(250)")]
        public string Customer_Name { get; set; }
        [Required, EmailAddress]
        [Column(TypeName = "Varchar(250)")]
        public string Customer_Email { get; set; }
        [Required]
        [Column(TypeName = "Varchar(250)")]
        public string Customer_Password { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
