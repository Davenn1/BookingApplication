using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public int Room_ID { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public string Movie_ID { get; set; }

        [ForeignKey("Movie_ID")]
        public Movie Movie { get; set; }
        public int Room_SeatCapacity { get; set; }
        public string Room_Type { get; set; }
        public string Room_Name { get; set; }
        public ICollection<Seats> Seatss { get; set; }

    }
}
