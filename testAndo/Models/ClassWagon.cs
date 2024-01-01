using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_INDIA.Models
{
    public class ClassWagon
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int quanity { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public TrainMaster TrainMaster { get; set; }
        public ICollection<TrainTickets>? TrainTickets { get; set; }
        public ICollection<Fare>? Fare { get; set; }
        public ClassWagon()
        {
            Id = Guid.NewGuid().ToString("N");
        }

    }
}
