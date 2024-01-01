using Microsoft.EntityFrameworkCore;

namespace API_INDIA.Models
{
    public class DBIndiaProjectContext : DbContext
    {
        public DBIndiaProjectContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StationMaster> StationMasters { get; set; }
      
        public DbSet<MiddleStation> MiddleStations { get; set; }
        public DbSet<TrainMaster> TrainMasters { get; set; }
        public DbSet<TrainSchedule> TrainSchedules { get; set; }
        public DbSet<ClassWagon> ClassWagons { get; set; }
        public DbSet<Fare> Fares { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }

        public DbSet<PassengerDetail> PassengerDetails { get; set; }
        public DbSet<TrainTickets> TrainTickets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassengerDetail>()
               .HasOne(a => a.TrainTickets)
               .WithMany(a => a.PassengerDetail)
               .HasForeignKey(a => a.PRN)
               .HasPrincipalKey(t => t.PRN);

            modelBuilder.Entity<MiddleStation>()
                 .HasOne(a => a.TrainSchedule)
                 .WithMany(a => a.MiddleStation)
                 .HasForeignKey(a => a.CodeSchedule)
                 .HasPrincipalKey(t => t.CodeSchedule);

            modelBuilder.Entity<MiddleStation>()
               .HasOne(ms => ms.StationMasterStart)
               .WithMany(ms => ms.MiddleStation)
               .HasForeignKey(ms => ms.StartStationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MiddleStation>()
                .HasOne(ms => ms.StationMasterEnd)
                .WithMany()
                .HasForeignKey(ms => ms.EndStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainSchedule>()
               .HasOne(ms => ms.StationMasterStart)
               .WithMany(ms => ms.TrainSchedules)
               .HasForeignKey(ms => ms.StartStationId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainSchedule>()
                .HasOne(ms => ms.StationMasterEnd)
                .WithMany()
                .HasForeignKey(ms => ms.EndStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainTickets>()
             .HasOne(ms => ms.StationMasterStart)
             .WithMany(ms => ms.TrainTickets)
             .HasForeignKey(ms => ms.StartStationId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainTickets>()
                .HasOne(ms => ms.StationMasterEnd)
                .WithMany()
                .HasForeignKey(ms => ms.EndStationId)
                .OnDelete(DeleteBehavior.Restrict);



            // Cấu hình khác...

            base.OnModelCreating(modelBuilder);
        }

    }
}