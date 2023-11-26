using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfInheritance.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmartPhone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameraSize = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartPhone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmartWatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartWatch", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SmartPhone",
                columns: new[] { "Id", "CameraSize", "Color", "Manufacturer", "Name" },
                values: new object[] { 1, 24, "Black", "Apple", "Iphone 4" });

            migrationBuilder.InsertData(
                table: "SmartWatch",
                columns: new[] { "Id", "Color", "Manufacturer", "Name" },
                values: new object[] { 1, "Gold", "SamSung", "Galaxy Gear3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmartPhone");

            migrationBuilder.DropTable(
                name: "SmartWatch");
        }
    }
}
