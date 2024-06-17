using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class CustomEnumNameSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Sick Leave");

            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Family Leave");

            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "Personal Leave");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "SickLeave");

            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "FamilyLeave");

            migrationBuilder.UpdateData(
                table: "AbsenceReasons",
                keyColumn: "ID",
                keyValue: 4,
                column: "Name",
                value: "PersonalLeave");
        }
    }
}
