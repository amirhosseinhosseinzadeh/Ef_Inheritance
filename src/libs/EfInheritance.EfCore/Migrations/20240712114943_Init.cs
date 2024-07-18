using System;
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
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoveringAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endorsement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EndorsementRegsterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndorsementEffectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndorsementEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndorsementCoveringAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endorsement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endorsement_Policy_Id",
                        column: x => x.Id,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Policy",
                columns: new[] { "Id", "CoveringAmount", "EffectionDate", "EndDate", "Title" },
                values: new object[,]
                {
                    { 1, 5000m, new DateTime(2024, 7, 12, 15, 19, 42, 927, DateTimeKind.Local).AddTicks(2329), new DateTime(2025, 7, 12, 15, 19, 42, 927, DateTimeKind.Local).AddTicks(2337), "Vehicle Thired party inssurance" },
                    { 2, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Endorsement",
                columns: new[] { "Id", "EndorsementCoveringAmount", "EndorsementEffectionDate", "EndorsementEndDate", "EndorsementRegsterDate" },
                values: new object[] { 2, 6000m, new DateTime(2024, 8, 12, 15, 19, 42, 927, DateTimeKind.Local).AddTicks(2459), new DateTime(2026, 8, 12, 15, 19, 42, 927, DateTimeKind.Local).AddTicks(2456), new DateTime(2024, 7, 12, 15, 19, 42, 927, DateTimeKind.Local).AddTicks(2460) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endorsement");

            migrationBuilder.DropTable(
                name: "Policy");
        }
    }
}
