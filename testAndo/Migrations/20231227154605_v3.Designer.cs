﻿// <auto-generated />
using System;
using API_INDIA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace testAndo.Migrations
{
    [DbContext(typeof(DBIndiaProjectContext))]
    [Migration("20231227154605_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_INDIA.Models.ClassWagon", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("TrainMasterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("quanity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainMasterId");

                    b.ToTable("ClassWagons");
                });

            modelBuilder.Entity("API_INDIA.Models.Fare", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClassWagonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("IdWagon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassWagonId");

                    b.ToTable("Fares");
                });

            modelBuilder.Entity("API_INDIA.Models.MiddleStation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EndStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberStation")
                        .HasColumnType("int");

                    b.Property<string>("StartStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("TimeEnd")
                        .HasColumnType("time");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("distance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CodeSchedule");

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.ToTable("MiddleStations");
                });

            modelBuilder.Entity("API_INDIA.Models.PassengerDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PRN");

                    b.ToTable("PassengerDetails");
                });

            modelBuilder.Entity("API_INDIA.Models.PaymentAccount", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Days")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberTickets")
                        .HasColumnType("int");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentMethods")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("PriceTicketCancellation")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("PaymentAccounts");
                });

            modelBuilder.Entity("API_INDIA.Models.StationMaster", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StationMasters");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainMaster", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("TrainMasters");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainSchedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CodeSchedule")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EndStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StartStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<TimeSpan>("TimeEnd")
                        .HasColumnType("time");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrainId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("distance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EndStationId");

                    b.HasIndex("StartStationId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainSchedules");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainTickets", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Days")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IDWagon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdPaymentAccount")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PRN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<string>("StartStationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TrainId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EndStationId");

                    b.HasIndex("IDWagon");

                    b.HasIndex("IdPaymentAccount");

                    b.HasIndex("StartStationId");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.ClassWagon", b =>
                {
                    b.HasOne("API_INDIA.Models.TrainMaster", "TrainMaster")
                        .WithMany()
                        .HasForeignKey("TrainMasterId");

                    b.Navigation("TrainMaster");
                });

            modelBuilder.Entity("API_INDIA.Models.Fare", b =>
                {
                    b.HasOne("API_INDIA.Models.ClassWagon", "ClassWagon")
                        .WithMany("Fare")
                        .HasForeignKey("ClassWagonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassWagon");
                });

            modelBuilder.Entity("API_INDIA.Models.MiddleStation", b =>
                {
                    b.HasOne("API_INDIA.Models.TrainSchedule", "TrainSchedule")
                        .WithMany("MiddleStation")
                        .HasForeignKey("CodeSchedule")
                        .HasPrincipalKey("CodeSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterEnd")
                        .WithMany()
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterStart")
                        .WithMany("MiddleStation")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StationMasterEnd");

                    b.Navigation("StationMasterStart");

                    b.Navigation("TrainSchedule");
                });

            modelBuilder.Entity("API_INDIA.Models.PassengerDetail", b =>
                {
                    b.HasOne("API_INDIA.Models.TrainTickets", "TrainTickets")
                        .WithMany("PassengerDetail")
                        .HasForeignKey("PRN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainSchedule", b =>
                {
                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterEnd")
                        .WithMany()
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterStart")
                        .WithMany("TrainSchedules")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.TrainMaster", "TrainMaster")
                        .WithMany()
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StationMasterEnd");

                    b.Navigation("StationMasterStart");

                    b.Navigation("TrainMaster");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainTickets", b =>
                {
                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterEnd")
                        .WithMany()
                        .HasForeignKey("EndStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.ClassWagon", "ClassWagon")
                        .WithMany("TrainTickets")
                        .HasForeignKey("IDWagon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.PaymentAccount", "PaymentAccount")
                        .WithMany("TrainTickets")
                        .HasForeignKey("IdPaymentAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.StationMaster", "StationMasterStart")
                        .WithMany("TrainTickets")
                        .HasForeignKey("StartStationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API_INDIA.Models.TrainMaster", "TrainMaster")
                        .WithMany("TrainTickets")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassWagon");

                    b.Navigation("PaymentAccount");

                    b.Navigation("StationMasterEnd");

                    b.Navigation("StationMasterStart");

                    b.Navigation("TrainMaster");
                });

            modelBuilder.Entity("API_INDIA.Models.ClassWagon", b =>
                {
                    b.Navigation("Fare");

                    b.Navigation("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.PaymentAccount", b =>
                {
                    b.Navigation("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.StationMaster", b =>
                {
                    b.Navigation("MiddleStation");

                    b.Navigation("TrainSchedules");

                    b.Navigation("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainMaster", b =>
                {
                    b.Navigation("TrainTickets");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainSchedule", b =>
                {
                    b.Navigation("MiddleStation");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainTickets", b =>
                {
                    b.Navigation("PassengerDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
