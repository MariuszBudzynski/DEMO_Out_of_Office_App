using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectStatuses_Statuses_StatusTypeID",
                table: "ProjectStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ProjectStatuses_StatusTypeID",
                table: "ProjectStatuses");

            migrationBuilder.RenameColumn(
                name: "StatusTypeID",
                table: "ProjectStatuses",
                newName: "StatusType");

            migrationBuilder.InsertData(
                table: "ProjectStatuses",
                columns: new[] { "ID", "StatusType" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Internal" },
                    { 2, "Client" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ID", "Comment", "EndDate", "ProjectManagerID", "ProjectTypeID", "StartDate", "StatusID" },
                values: new object[,]
                {
                    { 1, "Internal project for HR system", null, 2, 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Client project for ABC Inc.", null, 3, 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Research project", null, 4, 1, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Marketing campaign", null, 1, 2, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "IT infrastructure upgrade", null, 2, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Client project for XYZ Corp.", null, 3, 2, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Research and development", null, 4, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProjectStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "StatusType",
                table: "ProjectStatuses",
                newName: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatuses_StatusTypeID",
                table: "ProjectStatuses",
                column: "StatusTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectStatuses_Statuses_StatusTypeID",
                table: "ProjectStatuses",
                column: "StatusTypeID",
                principalTable: "Statuses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
