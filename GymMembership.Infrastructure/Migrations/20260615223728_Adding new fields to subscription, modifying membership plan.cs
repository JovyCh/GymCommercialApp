using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymMembership.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addingnewfieldstosubscriptionmodifyingmembershipplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledClasses_Instructors_InstructorId",
                table: "ScheduledClasses");

            migrationBuilder.RenameColumn(
                name: "DurationMonths",
                table: "MembershipPlans",
                newName: "DurationDays");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "ScheduledClasses",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "ScheduledClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMinutes",
                table: "ScheduledClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "ScheduledClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "ScheduledClasses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                table: "MembershipPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledClasses_Instructors_InstructorId",
                table: "ScheduledClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledClasses_Instructors_InstructorId",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "ScheduledClasses");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                table: "MembershipPlans");

            migrationBuilder.RenameColumn(
                name: "DurationDays",
                table: "MembershipPlans",
                newName: "DurationMonths");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstructorId",
                table: "ScheduledClasses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledClasses_Instructors_InstructorId",
                table: "ScheduledClasses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
