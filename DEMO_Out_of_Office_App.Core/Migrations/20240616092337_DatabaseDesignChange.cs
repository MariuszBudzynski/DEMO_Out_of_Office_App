using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseDesignChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalRequestStatuses_Statuses_StatusTypeID",
                table: "ApprovalRequestStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalRequestStatuses_StatusTypeID",
                table: "ApprovalRequestStatuses");

            migrationBuilder.RenameColumn(
                name: "StatusTypeID",
                table: "ApprovalRequestStatuses",
                newName: "StatusType");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ApprovalRequestStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 1,
                column: "Description",
                value: "New");

            migrationBuilder.UpdateData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 2,
                column: "Description",
                value: "Approve");

            migrationBuilder.UpdateData(
                table: "ApprovalRequestStatuses",
                keyColumn: "ID",
                keyValue: 3,
                column: "Description",
                value: "Reject");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ApprovalRequestStatuses");

            migrationBuilder.RenameColumn(
                name: "StatusType",
                table: "ApprovalRequestStatuses",
                newName: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStatuses_StatusTypeID",
                table: "ApprovalRequestStatuses",
                column: "StatusTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalRequestStatuses_Statuses_StatusTypeID",
                table: "ApprovalRequestStatuses",
                column: "StatusTypeID",
                principalTable: "Statuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
