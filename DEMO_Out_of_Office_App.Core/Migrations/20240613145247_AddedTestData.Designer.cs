﻿// <auto-generated />
using System;
using DEMOOutOfOfficeApp.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DEMOOutOfOfficeApp.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240613145247_AddedTestData")]
    partial class AddedTestData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.AbsenceReason", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AbsenceReasons");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ApproverID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveRequestID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ApproverID");

                    b.HasIndex("LeaveRequestID");

                    b.HasIndex("StatusID");

                    b.ToTable("ApprovalRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequestStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("StatusTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusTypeID");

                    b.ToTable("ApprovalRequestStatuses");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OutOfOfficeBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PeoplePartnerID")
                        .HasColumnType("int");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionID")
                        .HasColumnType("int");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.Property<int>("SubdivisionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PeoplePartnerID");

                    b.HasIndex("PositionID");

                    b.HasIndex("StatusID");

                    b.HasIndex("SubdivisionID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FullName = "John Doe",
                            OutOfOfficeBalance = 10.0m,
                            PeoplePartnerID = 1,
                            Photo = "john_doe.jpg",
                            PositionID = 1,
                            StatusID = 2,
                            SubdivisionID = 1
                        },
                        new
                        {
                            ID = 2,
                            FullName = "Jane Smith",
                            OutOfOfficeBalance = 15.0m,
                            PeoplePartnerID = 2,
                            Photo = "jane_smith.jpg",
                            PositionID = 3,
                            StatusID = 2,
                            SubdivisionID = 2
                        },
                        new
                        {
                            ID = 3,
                            FullName = "Alice Johnson",
                            OutOfOfficeBalance = 12.0m,
                            PeoplePartnerID = 1,
                            Photo = "alice_johnson.jpg",
                            PositionID = 1,
                            StatusID = 2,
                            SubdivisionID = 3
                        },
                        new
                        {
                            ID = 4,
                            FullName = "Bob Brown",
                            OutOfOfficeBalance = 8.0m,
                            PeoplePartnerID = 1,
                            Photo = "bob_brown.jpg",
                            PositionID = 4,
                            StatusID = 2,
                            SubdivisionID = 4
                        },
                        new
                        {
                            ID = 5,
                            FullName = "Charlie Davis",
                            OutOfOfficeBalance = 20.0m,
                            PeoplePartnerID = 3,
                            Photo = "charlie_davis.jpg",
                            PositionID = 2,
                            StatusID = 2,
                            SubdivisionID = 1
                        },
                        new
                        {
                            ID = 6,
                            FullName = "Diana Evans",
                            OutOfOfficeBalance = 18.0m,
                            PeoplePartnerID = 1,
                            Photo = "diana_evans.jpg",
                            PositionID = 3,
                            StatusID = 2,
                            SubdivisionID = 2
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = 0
                        },
                        new
                        {
                            ID = 2,
                            Name = 1
                        },
                        new
                        {
                            ID = 3,
                            Name = 2
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.LeaveRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AbsenceReasonID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AbsenceReasonID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("StatusID");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.LeaveRequestsStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("StatusTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusTypeID");

                    b.ToTable("LeaveRequestsStatuses");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Software Engineer"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Project Manager"
                        },
                        new
                        {
                            ID = 3,
                            Name = "HR Specialist"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Marketing Coordinator"
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjectManagerID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectTypeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProjectManagerID");

                    b.HasIndex("ProjectTypeID");

                    b.HasIndex("StatusID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ProjectStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("StatusTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StatusTypeID");

                    b.ToTable("ProjectStatuses");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ProjectType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DescriptionOfMainTasks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DescriptionOfMainTasks = "Creates a leave request",
                            UserRole = 0
                        },
                        new
                        {
                            ID = 2,
                            DescriptionOfMainTasks = "Manages the list of employees\n Approves/rejects requests",
                            UserRole = 1
                        },
                        new
                        {
                            ID = 3,
                            DescriptionOfMainTasks = "Manages the list of projects\n Approves/rejects requests",
                            UserRole = 2
                        },
                        new
                        {
                            ID = 4,
                            DescriptionOfMainTasks = "Grants access rights\n Manages all data",
                            UserRole = 3
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Subdivision", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Subdivisions");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Finance"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Human Resources"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Research and Development"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Marketing"
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            EmployeeID = 1,
                            PasswordHash = "7C6A180B36896A0A8C02787EEAFB0E4C",
                            Username = "john.doe"
                        },
                        new
                        {
                            ID = 2,
                            EmployeeID = 2,
                            PasswordHash = "6CB75F652A9B52798EB6CF2201057C73",
                            Username = "jane.smith"
                        },
                        new
                        {
                            ID = 3,
                            EmployeeID = 3,
                            PasswordHash = "819B0643D6B89DC9B579FDFC9094F28E",
                            Username = "alice.johnson"
                        },
                        new
                        {
                            ID = 4,
                            EmployeeID = 4,
                            PasswordHash = "34CC93ECE0BA9E3F6F235D4AF979B16C",
                            Username = "bob.brown"
                        },
                        new
                        {
                            ID = 5,
                            EmployeeID = 5,
                            PasswordHash = "DB0EDD04AAAC4506F7EDAB03AC855D56",
                            Username = "charlie.davis"
                        },
                        new
                        {
                            ID = 6,
                            EmployeeID = 6,
                            PasswordHash = "218DD27AEBECCECAE69AD8408D9A36BF",
                            Username = "diana.evans"
                        });
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequest", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Employee", "Approver")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("ApproverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.LeaveRequest", "LeaveRequest")
                        .WithMany()
                        .HasForeignKey("LeaveRequestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequestStatus", "ApprovalRequestStatus")
                        .WithMany("ApprovalRequests")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApprovalRequestStatus");

                    b.Navigation("Approver");

                    b.Navigation("LeaveRequest");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequestStatus", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", "StatusType")
                        .WithMany()
                        .HasForeignKey("StatusTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusType");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Employee", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Role", "PeoplePartner")
                        .WithMany()
                        .HasForeignKey("PeoplePartnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", "Status")
                        .WithMany("Employees")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PeoplePartner");

                    b.Navigation("Position");

                    b.Navigation("Status");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.LeaveRequest", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.AbsenceReason", "AbsenceReason")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("AbsenceReasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.LeaveRequestsStatus", "Status")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AbsenceReason");

                    b.Navigation("Employee");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.LeaveRequestsStatus", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", "StatusType")
                        .WithMany()
                        .HasForeignKey("StatusTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusType");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Project", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Employee", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.ProjectStatus", "ProjectStatus")
                        .WithMany("Projects")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProjectManager");

                    b.Navigation("ProjectStatus");

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ProjectStatus", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", "StatusType")
                        .WithMany()
                        .HasForeignKey("StatusTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StatusType");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.User", b =>
                {
                    b.HasOne("DEMOOutOfOfficeApp.Core.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.AbsenceReason", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ApprovalRequestStatus", b =>
                {
                    b.Navigation("ApprovalRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Employee", b =>
                {
                    b.Navigation("ApprovalRequests");

                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.EmployeeStatus", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.LeaveRequestsStatus", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ProjectStatus", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DEMOOutOfOfficeApp.Core.Entities.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
