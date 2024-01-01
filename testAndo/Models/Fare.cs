using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_INDIA.Models
{
    public class Fare
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string IdWagon { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }
        public ClassWagon ClassWagon { get; set; }

        public Fare()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
