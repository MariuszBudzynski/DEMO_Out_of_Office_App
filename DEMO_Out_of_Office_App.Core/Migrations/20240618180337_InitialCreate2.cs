using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 1,
                column: "ProjectManagerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 3,
                column: "ProjectManagerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 4,
                column: "ProjectManagerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 5,
                column: "ProjectManagerID",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 7,
                column: "ProjectManagerID",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 1,
                column: "ProjectManagerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 3,
                column: "ProjectManagerID",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 4,
                column: "ProjectManagerID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 5,
                column: "ProjectManagerID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 7,
                column: "ProjectManagerID",
                value: 4);
        }
    }
}
