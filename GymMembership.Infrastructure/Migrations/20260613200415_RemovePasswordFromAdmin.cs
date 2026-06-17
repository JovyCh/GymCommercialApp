using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMembership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePasswordFromAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Admins");

        }
    }
}
