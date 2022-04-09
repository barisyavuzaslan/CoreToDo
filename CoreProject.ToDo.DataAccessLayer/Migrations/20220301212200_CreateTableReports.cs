using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreProject.ToDo.DataAccessLayer.Migrations
{
    public partial class CreateTableReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "ntext", nullable: true),
                    ProcessId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProcessId",
                table: "Reports",
                column: "ProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
