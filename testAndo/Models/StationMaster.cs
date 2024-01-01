using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API_INDIA.Models
{
    public class StationMaster
    {
        [Key ]
        public string Id { get; set; }
        //[Required]
        //public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DivisionName { get; set; }
        public virtual ICollection<MiddleStation>? MiddleStation { get; set; }
        public ICollection<TrainSchedule>? TrainSchedules { get; set; }
        public ICollection<TrainTickets>? TrainTickets { get; set; }

        public StationMaster()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        //public StationMaster(DbContextOptions<DBIndiaProjectContext> options) : this()
        //{
        //    Code = GenerateUniqueCode(8, options);
        //}
        //private string GenerateUniqueCode(int length, DbContextOptions<DBIndiaProjectContext> options)
        //{
        //    string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        //    Random random = new Random();
        //    string code = new string(Enumerable.Repeat(characters, length)
        //                 .Select(s => s[random.Next(s.Length)]).ToArray());

        //     Kiểm tra sự trùng lặp
        //    while (CheckDuplicateCode(code, options))
        //    {
        //        code = new string(Enumerable.Repeat(characters, length)
        //             .Select(s => s[random.Next(s.Length)]).ToArray());
        //    }

        //    return code;
        //}

        //private bool CheckDuplicateCode(string code, DbContextOptions<DBIndiaProjectContext> options)
        //{
        //    using (var dbContext = new DBIndiaProjectContext(options))
        //    {
        //        return dbContext.StationMasters.Any(s => s.Code == code);
        //    }
        //}
    }  
}
