using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WaterConsumptionTracker.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersManagements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntakeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usage = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterRecords_UsersManagements_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersManagements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UsersManagements",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "customer@gmail.com", "John", "Hewitt" },
                    { 2, "Admin@gmail.com", "Jack", "Taylor" }
                });

            migrationBuilder.InsertData(
                table: "WaterRecords",
                columns: new[] { "Id", "IntakeDate", "Usage", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16777, 1 },
                    { 2, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 16377, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterRecords_UserId",
                table: "WaterRecords",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterRecords");

            migrationBuilder.DropTable(
                name: "UsersManagements");
        }
    }
}
