using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequestsExtended_ApprovalRequestID",
                table: "ApprovalRequestsExtended");

            migrationBuilder.RenameColumn(
                name: "PmManager",
                table: "ApprovalRequestsExtended",
                newName: "PmManagerId");

            migrationBuilder.RenameColumn(
                name: "HrManager",
                table: "ApprovalRequestsExtended",
                newName: "HrManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestsExtended_ApprovalRequestID",
                table: "ApprovalRequestsExtended",
                column: "ApprovalRequestID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequestsExtended_ApprovalRequestID",
                table: "ApprovalRequestsExtended");

            migrationBuilder.RenameColumn(
                name: "PmManagerId",
                table: "ApprovalRequestsExtended",
                newName: "PmManager");

            migrationBuilder.RenameColumn(
                name: "HrManagerId",
                table: "ApprovalRequestsExtended",
                newName: "HrManager");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestsExtended_ApprovalRequestID",
                table: "ApprovalRequestsExtended",
                column: "ApprovalRequestID");
        }
    }
}
