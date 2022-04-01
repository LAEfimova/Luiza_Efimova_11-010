using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCalculatorWithDI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    V1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    V2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Op = table.Column<int>(type: "int", nullable: false),
                    Res = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
