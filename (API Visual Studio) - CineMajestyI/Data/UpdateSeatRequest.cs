using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data
{
    public class UpdateSeatRequest
    {
        [Required]

        public int Seats_ID { get; set; }

        public int Ticket_ID { get; set; }

        [Required]
        public int Room_ID { get; set; }

        [Required]
        public int Seat_Number { get; set; }

        [Required]
        public Boolean Seat_IsAvailable { get; set; }
    }
}
