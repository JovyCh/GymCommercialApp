using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMembership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeAttendanceTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Members_MemberId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_ScheduledClasses_ScheduledClassId",
                table: "Attendance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ScheduledClassId",
                table: "Attendances",
                newName: "IX_Attendances_ScheduledClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_MemberId",
                table: "Attendances",
                newName: "IX_Attendances_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_ScheduledClasses_ScheduledClassId",
                table: "Attendances",
                column: "ScheduledClassId",
                principalTable: "ScheduledClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Members_MemberId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_ScheduledClasses_ScheduledClassId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_ScheduledClassId",
                table: "Attendance",
                newName: "IX_Attendance_ScheduledClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendances_MemberId",
                table: "Attendance",
                newName: "IX_Attendance_MemberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Members_MemberId",
                table: "Attendance",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_ScheduledClasses_ScheduledClassId",
                table: "Attendance",
                column: "ScheduledClassId",
                principalTable: "ScheduledClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
