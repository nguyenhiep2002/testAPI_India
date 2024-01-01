using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace API_INDIA.Models
{
    public class PaymentAccount
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Passport { get; set; }
        public string Email { get; set; }
        public string PaymentMethods { get; set; }
        public int Price { get; set; }
        public int NumberTickets { get; set; }
        public bool Status { get; set; }
        public bool PriceTicketCancellation { get; set; }
        [Column(TypeName = "date")]
        public DateTime Days {  get; set; }

        public ICollection<TrainTickets>? TrainTickets { get; set; }
        public PaymentAccount()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
