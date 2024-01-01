using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testAndo.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainMasters_StationMasters_StationMasterId",
                table: "TrainMasters");

            migrationBuilder.DropIndex(
                name: "IX_TrainMasters_StationMasterId",
                table: "TrainMasters");

            migrationBuilder.DropColumn(
                name: "StationMasterId",
                table: "TrainMasters");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "TrainTickets",
                newName: "PRN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PRN",
                table: "TrainTickets",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "StationMasterId",
                table: "TrainMasters",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TrainMasters_StationMasterId",
                table: "TrainMasters",
                column: "StationMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainMasters_StationMasters_StationMasterId",
                table: "TrainMasters",
                column: "StationMasterId",
                principalTable: "StationMasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
