using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Health.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyMetricLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "TEXT", nullable: false),
                    WaistNarrow = table.Column<decimal>(type: "TEXT", nullable: false),
                    WaistNaval = table.Column<decimal>(type: "TEXT", nullable: false),
                    Hips = table.Column<decimal>(type: "TEXT", nullable: false),
                    Chest = table.Column<decimal>(type: "TEXT", nullable: false),
                    Shoulders = table.Column<decimal>(type: "TEXT", nullable: false),
                    Biceps = table.Column<decimal>(type: "TEXT", nullable: false),
                    Forearms = table.Column<decimal>(type: "TEXT", nullable: false),
                    Thighs = table.Column<decimal>(type: "TEXT", nullable: false),
                    Calves = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyMetricLogs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyMetricLogs");
        }
    }
}
