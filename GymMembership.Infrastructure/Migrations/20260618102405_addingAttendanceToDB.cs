using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMembership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingAttendanceToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberScheduledClass");

            migrationBuilder.AddColumn<Guid>(
                name: "MemberId",
                table: "ScheduledClasses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledClassId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attended = table.Column<bool>(type: "bit", nullable: false),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_ScheduledClasses_ScheduledClassId",
                        column: x => x.ScheduledClassId,
                        principalTable: "ScheduledClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledClasses_MemberId",
                table: "ScheduledClasses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_MemberId",
                table: "Attendance",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_ScheduledClassId",
                table: "Attendance",
                column: "ScheduledClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledClasses_Members_MemberId",
                table: "ScheduledClasses",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledClasses_Members_MemberId",
                table: "ScheduledClasses");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledClasses_MemberId",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "ScheduledClasses");

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
    }
}
