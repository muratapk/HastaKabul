using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaKabul.Migrations
{
    public partial class paket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hastalars",
                columns: table => new
                {
                    HastaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HastaTc = table.Column<int>(type: "int", nullable: false),
                    HastaAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaYas = table.Column<int>(type: "int", nullable: false),
                    HastaEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HastaPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hastalars", x => x.HastaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hastalars");
        }
    }
}
