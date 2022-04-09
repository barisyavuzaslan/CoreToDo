using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreProject.ToDo.DataAccessLayer.Migrations
{
    public partial class AppUserAndProcessEROneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Processes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Processes_AppUserId",
                table: "Processes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_AspNetUsers_AppUserId",
                table: "Processes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_AspNetUsers_AppUserId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_AppUserId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
