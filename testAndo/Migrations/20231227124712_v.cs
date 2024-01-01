using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAndo.Migrations
{
    public partial class v : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StationMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainMasters",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StationMasterId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainMasters_StationMasters_StationMasterId",
                        column: x => x.StationMasterId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainSchedules",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeSchedule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainSchedules", x => x.Id);
                    table.UniqueConstraint("AK_TrainSchedules_CodeSchedule", x => x.CodeSchedule);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_StationMasters_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_StationMasters_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainSchedules_TrainMasters_TrainId",
                        column: x => x.TrainId,
                        principalTable: "TrainMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MiddleStations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CodeSchedule = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberStation = table.Column<int>(type: "int", nullable: false),
                    StartStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: false),
                    distance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiddleStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MiddleStations_StationMasters_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MiddleStations_StationMasters_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MiddleStations_TrainSchedules_CodeSchedule",
                        column: x => x.CodeSchedule,
                        principalTable: "TrainSchedules",
                        principalColumn: "CodeSchedule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiddleStations_CodeSchedule",
                table: "MiddleStations",
                column: "CodeSchedule");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleStations_EndStationId",
                table: "MiddleStations",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_MiddleStations_StartStationId",
                table: "MiddleStations",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainMasters_StationMasterId",
                table: "TrainMasters",
                column: "StationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_EndStationId",
                table: "TrainSchedules",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_StartStationId",
                table: "TrainSchedules",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainSchedules_TrainId",
                table: "TrainSchedules",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiddleStations");

            migrationBuilder.DropTable(
                name: "TrainSchedules");

            migrationBuilder.DropTable(
                name: "TrainMasters");

            migrationBuilder.DropTable(
                name: "StationMasters");
        }
    }
}
