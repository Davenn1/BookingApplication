using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        public string Movie_ID { get; set; }

        public ICollection<Room> Rooms{ get; set; }
    }
}
