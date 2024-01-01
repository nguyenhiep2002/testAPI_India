using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAndo.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerDetails_TrainTickets_PRN",
                table: "PassengerDetails");

            migrationBuilder.AlterColumn<string>(
                name: "PRN",
                table: "TrainTickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TrainTickets_PRN",
                table: "TrainTickets",
                column: "PRN");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerDetails_TrainTickets_PRN",
                table: "PassengerDetails",
                column: "PRN",
                principalTable: "TrainTickets",
                principalColumn: "PRN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerDetails_TrainTickets_PRN",
                table: "PassengerDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TrainTickets_PRN",
                table: "TrainTickets");

            migrationBuilder.AlterColumn<string>(
                name: "PRN",
                table: "TrainTickets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerDetails_TrainTickets_PRN",
                table: "PassengerDetails",
                column: "PRN",
                principalTable: "TrainTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
