using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INDIA.Models
{
    public class PassengerDetail
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [ForeignKey("TrainTickets")]
        public string PRN { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public bool Gender {  get; set; }
        public string Passport { get; set; }

        public TrainTickets TrainTickets { get; set; }

    }
}
