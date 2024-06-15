using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbsenceReasons",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbsenceReasons", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    UserRoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionOfMainTasks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequestStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApprovalRequestStatuses_Statuses_StatusTypeID",
                        column: x => x.StatusTypeID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestsStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestsStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveRequestsStatuses_Statuses_StatusTypeID",
                        column: x => x.StatusTypeID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectStatuses_Statuses_StatusTypeID",
                        column: x => x.StatusTypeID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubdivisionID = table.Column<int>(type: "int", nullable: false),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    PeoplePartnerID = table.Column<int>(type: "int", nullable: false),
                    OutOfOfficeBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_PeoplePartnerID",
                        column: x => x.PeoplePartnerID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Subdivisions_SubdivisionID",
                        column: x => x.SubdivisionID,
                        principalTable: "Subdivisions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AbsenceReasonID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_AbsenceReasons_AbsenceReasonID",
                        column: x => x.AbsenceReasonID,
                        principalTable: "AbsenceReasons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveRequestsStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "LeaveRequestsStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectManagerID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerID",
                        column: x => x.ProjectManagerID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "ProjectStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes_ProjectTypeID",
                        column: x => x.ProjectTypeID,
                        principalTable: "ProjectTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApproverID = table.Column<int>(type: "int", nullable: false),
                    LeaveRequestID = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_ApprovalRequestStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "ApprovalRequestStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_Employees_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_LeaveRequests_LeaveRequestID",
                        column: x => x.LeaveRequestID,
                        principalTable: "LeaveRequests",
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
                table: "Roles",
                columns: new[] { "ID", "DescriptionOfMainTasks", "UserRole", "UserRoleDescription" },
                values: new object[,]
                {
                    { 1, "Creates a leave request", 1, "Employee" },
                    { 2, "Manages the list of employees\n Approves/rejects requests", 2, "HRManager" },
                    { 3, "Manages the list of projects\n Approves/rejects requests", 3, "ProjectManager" },
                    { 4, "Grants access rights\n Manages all data", 4, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "ID", "StatusDescription", "StatusId" },
                values: new object[,]
                {
                    { 1, "New", 1 },
                    { 2, "Active", 2 },
                    { 3, "Inactive", 3 }
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
                    { 1, "John Doe", 10.0m, 1, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 1, 2, 1 },
                    { 2, "Jane Smith", 15.0m, 2, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 3, 2, 2 },
                    { 3, "Alice Johnson", 12.0m, 1, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 1, 2, 3 },
                    { 4, "Bob Brown", 8.0m, 1, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 4, 2, 4 },
                    { 5, "Charlie Davis", 20.0m, 3, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 2, 2, 1 },
                    { 6, "Diana Evans", 18.0m, 1, new byte[] { 255, 216, 255, 224, 0, 16, 74, 70, 73, 70, 0, 1, 1, 1, 0, 96, 0, 96, 0, 0, 255, 219, 0, 67, 0 }, 3, 2, 2 }
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
                name: "IX_ApprovalRequests_ApproverID",
                table: "ApprovalRequests",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_LeaveRequestID",
                table: "ApprovalRequests",
                column: "LeaveRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_StatusID",
                table: "ApprovalRequests",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequestStatuses_StatusTypeID",
                table: "ApprovalRequestStatuses",
                column: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PeoplePartnerID",
                table: "Employees",
                column: "PeoplePartnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusID",
                table: "Employees",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionID",
                table: "Employees",
                column: "SubdivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_AbsenceReasonID",
                table: "LeaveRequests",
                column: "AbsenceReasonID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeID",
                table: "LeaveRequests",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_StatusID",
                table: "LeaveRequests",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequestsStatuses_StatusTypeID",
                table: "LeaveRequestsStatuses",
                column: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerID",
                table: "Projects",
                column: "ProjectManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeID",
                table: "Projects",
                column: "ProjectTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusID",
                table: "Projects",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStatuses_StatusTypeID",
                table: "ProjectStatuses",
                column: "StatusTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ApprovalRequestStatuses");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "AbsenceReasons");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "LeaveRequestsStatuses");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Subdivisions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
