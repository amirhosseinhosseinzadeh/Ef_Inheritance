using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EfInheritance.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gadget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GadgetType = table.Column<string>(name: "Gadget_Type", type: "nvarchar(max)", nullable: false),
                    CameraSize = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontCameraSize = table.Column<int>(type: "int", nullable: true),
                    BandColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmartWatchCameraSize = table.Column<int>(name: "SmartWatch_CameraSize", type: "int", nullable: true),
                    HeartBeatSensor = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gadget", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Gadget",
                columns: new[] { "Id", "CameraSize", "Color", "FrontCameraSize", "Gadget_Type", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 1, 20, "Rose Gold", 12, "SmartPhone", "Apple", "IPhone 14 pro max" },
                    { 2, 15, "metallic black", 7, "SmartPhone", "SamSung", "Galaxy Note3" }
                });

            migrationBuilder.InsertData(
                table: "Gadget",
                columns: new[] { "Id", "BandColor", "SmartWatch_CameraSize", "Color", "Gadget_Type", "HeartBeatSensor", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 3, "Silver", 15, "Silver", "SmartWatch", true, "Apple", "Iwatch 13" },
                    { 4, "balck", 15, "Gold", "SmartWatch", false, "SamSung", "Galaxy Gear 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gadget");
        }
    }
}
