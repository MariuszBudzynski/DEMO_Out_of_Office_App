using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Statuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Software Engineer" },
                    { 2, "Project Manager" },
                    { 3, "HR Specialist" },
                    { 4, "Marketing Coordinator" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Subdivisions",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Finance" },
                    { 2, "Human Resources" },
                    { 3, "Research and Development" },
                    { 4, "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "FullName", "OutOfOfficeBalance", "PeoplePartnerID", "Photo", "PositionID", "StatusID", "SubdivisionID" },
                values: new object[,]
                {
                    { 1, "John Doe", 10.0m, 1, "john_doe.jpg", 1, 2, 1 },
                    { 2, "Jane Smith", 15.0m, 2, "jane_smith.jpg", 3, 2, 2 },
                    { 3, "Alice Johnson", 12.0m, 1, "alice_johnson.jpg", 1, 2, 3 },
                    { 4, "Bob Brown", 8.0m, 1, "bob_brown.jpg", 4, 2, 4 },
                    { 5, "Charlie Davis", 20.0m, 3, "charlie_davis.jpg", 2, 2, 1 },
                    { 6, "Diana Evans", 18.0m, 1, "diana_evans.jpg", 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "EmployeeID", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, 1, "7C6A180B36896A0A8C02787EEAFB0E4C", "john.doe" },
                    { 2, 2, "6CB75F652A9B52798EB6CF2201057C73", "jane.smith" },
                    { 3, 3, "819B0643D6B89DC9B579FDFC9094F28E", "alice.johnson" },
                    { 4, 4, "34CC93ECE0BA9E3F6F235D4AF979B16C", "bob.brown" },
                    { 5, 5, "DB0EDD04AAAC4506F7EDAB03AC855D56", "charlie.davis" },
                    { 6, 6, "218DD27AEBECCECAE69AD8408D9A36BF", "diana.evans" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subdivisions",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
