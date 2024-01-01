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
    [Migration("20231227124712_v")]
    partial class v
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    b.Property<string>("StationMasterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StationMasterId");

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

            modelBuilder.Entity("API_INDIA.Models.TrainMaster", b =>
                {
                    b.HasOne("API_INDIA.Models.StationMaster", null)
                        .WithMany("TrainMasters")
                        .HasForeignKey("StationMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("API_INDIA.Models.StationMaster", b =>
                {
                    b.Navigation("MiddleStation");

                    b.Navigation("TrainMasters");

                    b.Navigation("TrainSchedules");
                });

            modelBuilder.Entity("API_INDIA.Models.TrainSchedule", b =>
                {
                    b.Navigation("MiddleStation");
                });
#pragma warning restore 612, 618
        }
    }
}
