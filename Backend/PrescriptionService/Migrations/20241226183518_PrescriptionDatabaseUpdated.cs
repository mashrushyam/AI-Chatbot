using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrescriptionService.Migrations
{
    /// <inheritdoc />
    public partial class PrescriptionDatabaseUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Prescriptions");
        }
    }
}
