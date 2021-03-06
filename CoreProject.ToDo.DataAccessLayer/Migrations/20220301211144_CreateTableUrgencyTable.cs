using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreProject.ToDo.DataAccessLayer.Migrations
{
    public partial class CreateTableUrgencyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "Processes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgencies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgencies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_UrgencyId",
                table: "Processes",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Urgencies_UrgencyId",
                table: "Processes",
                column: "UrgencyId",
                principalTable: "Urgencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Urgencies_UrgencyId",
                table: "Processes");

            migrationBuilder.DropTable(
                name: "Urgencies");

            migrationBuilder.DropIndex(
                name: "IX_Processes_UrgencyId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "Processes");
        }
    }
}
