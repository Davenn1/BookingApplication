using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models
{
    [Table("Booking")]
    public class Booking
    {
        [Key]
        public int Booking_ID { get; set; }
        public string Movie_ID { get; set; }

        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
