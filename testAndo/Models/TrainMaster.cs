using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INDIA.Models
{
    public class TrainMaster
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Status { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<TrainTickets>? TrainTickets { get; set; }
        public TrainMaster()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
