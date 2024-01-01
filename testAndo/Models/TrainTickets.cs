using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testAndo.Extentions;

namespace API_INDIA.Models
{
    public class TrainTickets
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string PRN { get; set; }
        [Required]
        [ForeignKey("TrainMaster")]
        public string TrainId { get; set; }
        [Required]
        [ForeignKey("StationMasterStart")]
        public string StartStationId { get; set; }
        [Required]
        [ForeignKey("StationMasterEnd")]
        public string EndStationId { get; set; }
        [Required]
        public int Seats {  get; set; }
        [Required]
        [ForeignKey("ClassWagon")]
        public string IDWagon { get; set; }
        [Column(TypeName = "date")]
        public DateTime Days { get; set; }
        public int Price { get; set; }
        [ForeignKey("PaymentAccount")]
        public string IdPaymentAccount { get; set; }

        public StationMaster StationMasterStart { get; set; }

        public StationMaster StationMasterEnd { get; set; }
        public TrainMaster TrainMaster { get; set; }
        public PaymentAccount PaymentAccount { get; set; }
        public ClassWagon ClassWagon { get; set; }

        public ICollection<PassengerDetail>? PassengerDetail { get; set; }

        public TrainTickets()
        {
            Id = Guid.NewGuid().ToString("N");
            PRN = RandomCode.GenerateUniqueCode(12);
        }

      
    }
}
