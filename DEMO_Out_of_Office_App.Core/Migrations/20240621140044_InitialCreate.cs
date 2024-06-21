﻿using System;
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
                name: "ApprovalRequestStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequestStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequestsStatuses",
                columns: table => new
                {
                    StatusType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequestsStatuses", x => x.StatusType);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatuses", x => x.ID);
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
                    OutOfOfficeBalance = table.Column<int>(type: "int", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_PositionID",
                        column: x => x.PositionID,
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
                    StatusType = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_LeaveRequests_LeaveRequestsStatuses_StatusType",
                        column: x => x.StatusType,
                        principalTable: "LeaveRequestsStatuses",
                        principalColumn: "StatusType",
                        onDelete: ReferentialAction.Cascade);
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
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Projects_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Projects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveRequestID = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ApproverID = table.Column<int>(type: "int", nullable: false),
                    RequestAproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_ApprovalRequestStatuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "ApprovalRequestStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_LeaveRequests_LeaveRequestID",
                        column: x => x.LeaveRequestID,
                        principalTable: "LeaveRequests",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_Users_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AbsenceReasons",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Vacation" },
                    { 2, "Sick Leave" },
                    { 3, "Family Leave" },
                    { 4, "Personal Leave" }
                });

            migrationBuilder.InsertData(
                table: "ApprovalRequestStatuses",
                columns: new[] { "ID", "Description", "StatusType" },
                values: new object[,]
                {
                    { 1, "New", 1 },
                    { 2, "Approved", 2 },
                    { 3, "Rejected", 3 },
                    { 4, "Cancelled", 4 }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequestsStatuses",
                columns: new[] { "StatusType", "Description" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Approved" },
                    { 3, "Rejected" },
                    { 4, "Cancelled" }
                });

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
                    { 2, "Jane Smith", 15, 5, null, 3, 2, 2 },
                    { 3, "Alice Johnson", 12, 1, null, 1, 2, 3 },
                    { 4, "Bob Brown", 8, 5, null, 4, 2, 4 },
                    { 5, "Charlie Davis", 20, 1, null, 2, 2, 1 },
                    { 6, "Diana Evans", 18, 5, null, 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "ID", "AbsenceReasonID", "Comment", "EmployeeID", "EndDate", "StartDate", "StatusType" },
                values: new object[,]
                {
                    { 1, 4, "Vacation", 1, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, "Medical leave", 2, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, "Family event", 3, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 3, "Business trip", 4, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ID", "Comment", "EndDate", "ProjectManagerID", "ProjectTypeID", "StartDate", "StatusID" },
                values: new object[,]
                {
                    { 1, "Internal project for HR system", null, 3, 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Client project for ABC Inc.", null, 3, 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "Research project", null, 3, 1, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "Marketing campaign", null, 3, 2, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, "IT infrastructure upgrade", null, 3, 1, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, "Client project for XYZ Corp.", null, 3, 2, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, "Research and development", null, 3, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "EmployeeID", "FullName", "PasswordHash", "RoleID", "Username" },
                values: new object[,]
                {
                    { 1, 1, "John Doe", "7C6A180B36896A0A8C02787EEAFB0E4C", 2, "john.doe" },
                    { 2, 2, "Jane Smith", "6CB75F652A9B52798EB6CF2201057C73", 4, "jane.smith" },
                    { 3, 3, "Alice Johnson", "819B0643D6B89DC9B579FDFC9094F28E", 3, "alice.johnson" },
                    { 4, 4, "Bob Brown", "34CC93ECE0BA9E3F6F235D4AF979B16C", 1, "bob.brown" },
                    { 5, 5, "Charlie Davis", "DB0EDD04AAAC4506F7EDAB03AC855D56", 2, "charlie.davis" },
                    { 6, 6, "Diana Evans", "218DD27AEBECCECAE69AD8408D9A36BF", 1, "diana.evans" }
                });

            migrationBuilder.InsertData(
                table: "ApprovalRequests",
                columns: new[] { "ID", "ApproverID", "Comment", "EmployeeId", "LeaveRequestID", "RequestAproved", "StatusID" },
                values: new object[,]
                {
                    { 1, 5, "Initial approval request", 1, 1, false, 1 },
                    { 2, 1, "Approved by HR", 2, 2, true, 2 },
                    { 3, 3, "Rejected by PM", 3, 3, false, 3 },
                    { 4, 5, "Initial approval request", 4, 4, false, 1 },
                    { 5, 1, "Approved by HR", 5, 1, true, 2 },
                    { 6, 3, "Rejected by PM", 6, 2, false, 3 }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployee",
                columns: new[] { "ID", "EmployeeID", "ProjectID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 2 },
                    { 5, 3, 3 },
                    { 6, 4, 3 },
                    { 7, 4, 4 },
                    { 8, 5, 4 },
                    { 9, 5, 5 },
                    { 10, 6, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_ApproverID",
                table: "ApprovalRequests",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_EmployeeId",
                table: "ApprovalRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_LeaveRequestID",
                table: "ApprovalRequests",
                column: "LeaveRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_StatusID",
                table: "ApprovalRequests",
                column: "StatusID");

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
                name: "IX_LeaveRequests_StatusType",
                table: "LeaveRequests",
                column: "StatusType");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeID",
                table: "ProjectEmployee",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_ProjectID",
                table: "ProjectEmployee",
                column: "ProjectID");

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
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "ApprovalRequestStatuses");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AbsenceReasons");

            migrationBuilder.DropTable(
                name: "LeaveRequestsStatuses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ProjectStatuses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Subdivisions");
        }
    }
}