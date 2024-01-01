using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INDIA.Models
{
    public class MiddleStation
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [ForeignKey("CodeSchedule")]
        public string CodeSchedule {  get; set; }
        [Required]
        public int NumberStation  { get; set; }
        [Required]
        [ForeignKey("StationMasterStart")]
        public string StartStationId { get; set; }

        [Required]
        [ForeignKey("StationMasterEnd")]
        public string EndStationId { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeStart { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan TimeEnd { get; set; }

        public int distance { get; set; }
        public StationMaster StationMasterEnd { get; set; }
        public StationMaster StationMasterStart { get; set; }
        public TrainSchedule TrainSchedule { get; set; }


        public MiddleStation()
        {
            Id = Guid.NewGuid().ToString("N");
        }
    }
}
