using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
