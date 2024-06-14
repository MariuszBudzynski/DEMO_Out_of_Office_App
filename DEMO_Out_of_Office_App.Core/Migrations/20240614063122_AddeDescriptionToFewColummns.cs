using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddeDescriptionToFewColummns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusDescription",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserRoleDescription",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "UserRoleDescription",
                value: "Employee");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "UserRoleDescription",
                value: "HRManager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 3,
                column: "UserRoleDescription",
                value: "ProjectManager");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 4,
                column: "UserRoleDescription",
                value: "Administrator");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 1,
                column: "StatusDescription",
                value: "New");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 2,
                column: "StatusDescription",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "StatusDescription",
                value: "Inactive");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDescription",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "UserRoleDescription",
                table: "Roles");
        }
    }
}
