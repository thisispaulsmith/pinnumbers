using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PinNumbers",
                columns: table => new
                {
                    Pin = table.Column<string>(nullable: false),
                    Consumed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinNumbers", x => x.Pin);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PinNumbers");
        }
    }
}
