using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAndo.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassWagons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quanity = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    TrainMasterId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassWagons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassWagons_TrainMasters_TrainMasterId",
                        column: x => x.TrainMasterId,
                        principalTable: "TrainMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentAccounts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    NumberTickets = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    PriceTicketCancellation = table.Column<bool>(type: "bit", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fares",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdWagon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ClassWagonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fares_ClassWagons_ClassWagonId",
                        column: x => x.ClassWagonId,
                        principalTable: "ClassWagons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainTickets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EndStationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    IDWagon = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IdPaymentAccount = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainTickets_ClassWagons_IDWagon",
                        column: x => x.IDWagon,
                        principalTable: "ClassWagons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainTickets_PaymentAccounts_IdPaymentAccount",
                        column: x => x.IdPaymentAccount,
                        principalTable: "PaymentAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrainTickets_StationMasters_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainTickets_StationMasters_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "StationMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainTickets_TrainMasters_TrainId",
                        column: x => x.TrainId,
                        principalTable: "TrainMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PRN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Passport = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_TrainTickets_PRN",
                        column: x => x.PRN,
                        principalTable: "TrainTickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassWagons_TrainMasterId",
                table: "ClassWagons",
                column: "TrainMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Fares_ClassWagonId",
                table: "Fares",
                column: "ClassWagonId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_PRN",
                table: "PassengerDetails",
                column: "PRN");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_EndStationId",
                table: "TrainTickets",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_IdPaymentAccount",
                table: "TrainTickets",
                column: "IdPaymentAccount");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_IDWagon",
                table: "TrainTickets",
                column: "IDWagon");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_StartStationId",
                table: "TrainTickets",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainTickets_TrainId",
                table: "TrainTickets",
                column: "TrainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fares");

            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "TrainTickets");

            migrationBuilder.DropTable(
                name: "ClassWagons");

            migrationBuilder.DropTable(
                name: "PaymentAccounts");
        }
    }
}
