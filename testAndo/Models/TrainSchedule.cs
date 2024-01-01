using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using testAndo.Extentions;

namespace API_INDIA.Models
{
    public class TrainSchedule
    {
        [Key ]
        public string Id { get; set; }
        [Required]
        public string CodeSchedule { get; set; }
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
        [Column(TypeName = "time")]
        public TimeSpan TimeStart { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeEnd { get; set; }
        
        public int distance {  get; set; }

        public StationMaster? StationMasterStart { get; set; }
         
        public StationMaster? StationMasterEnd { get; set; }
        public TrainMaster? TrainMaster { get; set; }
        public ICollection<MiddleStation>? MiddleStation { get; set; }
        public TrainSchedule()
        {
            Id = Guid.NewGuid().ToString("N");
            CodeSchedule = RandomCode.GenerateUniqueCode(8);
        }

     
    }
}
