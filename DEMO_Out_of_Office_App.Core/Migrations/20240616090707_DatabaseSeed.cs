using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApprovalRequestStatuses",
                columns: new[] { "ID", "StatusTypeID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "ApprovalRequests",
                columns: new[] { "ID", "ApproverID", "Comment", "LeaveRequestID", "StatusID" },
                values: new object[,]
                {
                    { 1, 2, "Approved", 1, 1 },
                    { 2, 3, "Pending review", 2, 2 },
                    { 3, 4, "Approved for family event", 3, 1 },
                    { 4, 2, "Rejected due to conflicting schedule", 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ApprovalRequests",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
