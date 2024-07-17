
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models
{
    [Table("Seats")]
    public class Seats
    {
        [Key]
        public int Seats_ID { get; set; }

        [Required]
        [ForeignKey("Ticket")]
        public int Ticket_ID { get; set; }
        public Ticket Ticket { get; set; }

        [Required]
        [ForeignKey("Room")]
        public int Room_ID { get; set; }
        public Room Room { get; set; } 

        public int Seat_Number { get; set; }

        public Boolean Seat_IsAvailable { get; set; }

    }
}
