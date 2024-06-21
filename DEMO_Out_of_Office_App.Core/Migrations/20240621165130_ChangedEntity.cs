using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestAproved",
                table: "ApprovalRequests");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequestAproved",
                table: "ApprovalRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 1,
                column: "RequestAproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 2,
                column: "RequestAproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 3,
                column: "RequestAproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 4,
                column: "RequestAproved",
                value: false);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 5,
                column: "RequestAproved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 6,
                column: "RequestAproved",
                value: false);
        }
    }
}
