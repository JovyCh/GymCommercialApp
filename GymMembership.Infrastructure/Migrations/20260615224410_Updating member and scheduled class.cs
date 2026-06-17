using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMembership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatingmemberandscheduledclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_ScheduledClasses_ScheduledClassId",
                table: "Members");

            migrationBuilder.DropIndex(
                name: "IX_Members_ScheduledClassId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ScheduledClassId",
                table: "Members");

            migrationBuilder.CreateTable(
                name: "MemberScheduledClass",
                columns: table => new
                {
                    AttendeesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookedClassesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberScheduledClass", x => new { x.AttendeesId, x.BookedClassesId });
                    table.ForeignKey(
                        name: "FK_MemberScheduledClass_Members_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberScheduledClass_ScheduledClasses_BookedClassesId",
                        column: x => x.BookedClassesId,
                        principalTable: "ScheduledClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberScheduledClass_BookedClassesId",
                table: "MemberScheduledClass",
                column: "BookedClassesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberScheduledClass");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduledClassId",
                table: "Members",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_ScheduledClassId",
                table: "Members",
                column: "ScheduledClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_ScheduledClasses_ScheduledClassId",
                table: "Members",
                column: "ScheduledClassId",
                principalTable: "ScheduledClasses",
                principalColumn: "Id");
        }
    }
}
