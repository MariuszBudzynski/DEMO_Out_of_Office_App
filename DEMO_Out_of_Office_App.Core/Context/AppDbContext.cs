using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DEMOOutOfOfficeApp.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subdivision> Subdivisions { get; set; }
        public DbSet<EmployeeStatus> Statuses { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LeaveRequestsStatus> LeaveRequestsStatuses { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<ApprovalRequestStatus> ApprovalRequestStatuses { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
        public DbSet<AbsenceReason> AbsenceReasons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var placeholderPhoto = "wwwroot/images/Test.jpg";
            byte[] placeholderPhotoConversion = File.Exists(placeholderPhoto) ? File.ReadAllBytes(placeholderPhoto) : new byte[0];

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectStatus)
                .WithMany(ps => ps.Projects)
                .HasForeignKey(p => p.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectType)
                .WithMany(pt => pt.Projects)
                .HasForeignKey(p => p.ProjectTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for roles
            modelBuilder.Entity<Role>().HasData(
                new Role { ID = 1, UserRole = UserRole.Employee, UserRoleDescription = UserRole.Employee.ToString(), DescriptionOfMainTasks = "Creates a leave request" },
                new Role { ID = 2, UserRole = UserRole.HRManager, UserRoleDescription = UserRole.HRManager.ToString(), DescriptionOfMainTasks = "Manages the list of employees\n Approves/rejects requests" },
                new Role { ID = 3, UserRole = UserRole.ProjectManager, UserRoleDescription = UserRole.ProjectManager.ToString(), DescriptionOfMainTasks = "Manages the list of projects\n Approves/rejects requests" },
                new Role { ID = 4, UserRole = UserRole.Administrator, UserRoleDescription = UserRole.Administrator.ToString(), DescriptionOfMainTasks = "Grants access rights\n Manages all data" }
            );

            // Seed data for subdivisions
            modelBuilder.Entity<Subdivision>().HasData(
                new Subdivision { ID = 1, Name = "Finance" },
                new Subdivision { ID = 2, Name = "Human Resources" },
                new Subdivision { ID = 3, Name = "Research and Development" },
                new Subdivision { ID = 4, Name = "Marketing" }
            );

            // Seed data for employee statuses
            modelBuilder.Entity<EmployeeStatus>().HasData(
                new EmployeeStatus { ID = 1, StatusId = Status.New, StatusDescription = Status.New.ToString() },
                new EmployeeStatus { ID = 2, StatusId = Status.Active, StatusDescription = Status.Active.ToString() },
                new EmployeeStatus { ID = 3, StatusId = Status.Inactive, StatusDescription = Status.Inactive.ToString() }
            );

            // Seed data for employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, FullName = "John Doe", SubdivisionID = 1, PositionID = 1, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 10, Photo = placeholderPhotoConversion },
                new Employee { ID = 2, FullName = "Jane Smith", SubdivisionID = 2, PositionID = 3, StatusID = 2, PeoplePartnerID = 5, OutOfOfficeBalance = 15 },
                new Employee { ID = 3, FullName = "Alice Johnson", SubdivisionID = 3, PositionID = 1, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 12 },
                new Employee { ID = 4, FullName = "Bob Brown", SubdivisionID = 4, PositionID = 4, StatusID = 2, PeoplePartnerID = 5, OutOfOfficeBalance = 8 },
                new Employee { ID = 5, FullName = "Charlie Davis", SubdivisionID = 1, PositionID = 2, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 20},
                new Employee { ID = 6, FullName = "Diana Evans", SubdivisionID = 2, PositionID = 3, StatusID = 2, PeoplePartnerID = 5, OutOfOfficeBalance = 18 }
            );

            // Seed data for users
            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, EmployeeID = 1, FullName = "John Doe", Username = "john.doe", PasswordHash = GetMd5Hash("password1"), RoleID = (int)UserRole.HRManager },
                new User { ID = 2, EmployeeID = 2, FullName = "Jane Smith", Username = "jane.smith", PasswordHash = GetMd5Hash("password2"), RoleID = (int)UserRole.Administrator },
                new User { ID = 3, EmployeeID = 3, FullName = "Alice Johnson", Username = "alice.johnson", PasswordHash = GetMd5Hash("password3"), RoleID = (int)UserRole.ProjectManager },
                new User { ID = 4, EmployeeID = 4, FullName = "Bob Brown", Username = "bob.brown", PasswordHash = GetMd5Hash("password4"), RoleID = (int)UserRole.Employee },
                new User { ID = 5, EmployeeID = 5, FullName = "Charlie Davis", Username = "charlie.davis", PasswordHash = GetMd5Hash("password5"), RoleID = (int)UserRole.HRManager },
                new User { ID = 6, EmployeeID = 6, FullName = "Diana Evans", Username = "diana.evans", PasswordHash = GetMd5Hash("password6"), RoleID = (int)UserRole.Employee }
            );

            // Seed data for leave requests statuses
            modelBuilder.Entity<LeaveRequestsStatus>().HasData(
                new LeaveRequestsStatus { StatusType = LeaveRequestsStatusType.New, Description = LeaveRequestsStatusType.New.ToString() },
                new LeaveRequestsStatus { StatusType = LeaveRequestsStatusType.Approved, Description = LeaveRequestsStatusType.Approved.ToString() },
                new LeaveRequestsStatus { StatusType = LeaveRequestsStatusType.Rejected, Description = LeaveRequestsStatusType.Rejected.ToString() },
                new LeaveRequestsStatus { StatusType = LeaveRequestsStatusType.Cancelled, Description = LeaveRequestsStatusType.Cancelled.ToString() }
            );

            // Seed data for absence reasons
            modelBuilder.Entity<AbsenceReason>().HasData(
                new AbsenceReason { ID = (int)AbsenceReasonType.Vacation, Name = GetDisplayName(AbsenceReasonType.Vacation) },
                new AbsenceReason { ID = (int)AbsenceReasonType.SickLeave, Name = GetDisplayName(AbsenceReasonType.SickLeave) },
                new AbsenceReason { ID = (int)AbsenceReasonType.FamilyLeave, Name = GetDisplayName(AbsenceReasonType.FamilyLeave) },
                new AbsenceReason { ID = (int)AbsenceReasonType.PersonalLeave, Name = GetDisplayName(AbsenceReasonType.PersonalLeave) }
            );

            // Seed data for leave requests
            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest { ID = 1, EmployeeID = 1, AbsenceReasonID = 4, StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2023, 6, 15), Comment = "Vacation", StatusType = LeaveRequestsStatusType.New },
                new LeaveRequest { ID = 2, EmployeeID = 2, AbsenceReasonID = 2, StartDate = new DateTime(2023, 7, 10), EndDate = new DateTime(2023, 7, 20), Comment = "Medical leave", StatusType = LeaveRequestsStatusType.Approved },
                new LeaveRequest { ID = 3, EmployeeID = 3, AbsenceReasonID = 1, StartDate = new DateTime(2023, 8, 5), EndDate = new DateTime(2023, 8, 15), Comment = "Family event", StatusType = LeaveRequestsStatusType.Rejected },
                new LeaveRequest { ID = 4, EmployeeID = 4, AbsenceReasonID = 3, StartDate = new DateTime(2023, 9, 1), EndDate = new DateTime(2023, 9, 10), Comment = "Business trip", StatusType = LeaveRequestsStatusType.New }
            );

            // Seed data for approval requests statuses
            modelBuilder.Entity<ApprovalRequestStatus>().HasData(
                new ApprovalRequestStatus { ID = 1, StatusType = ApprovalRequestStatusType.New, Description = ApprovalRequestStatusType.New.ToString() },
                new ApprovalRequestStatus { ID = 2, StatusType = ApprovalRequestStatusType.Approved, Description = ApprovalRequestStatusType.Approved.ToString() },
                new ApprovalRequestStatus { ID = 3, StatusType = ApprovalRequestStatusType.Rejected, Description = ApprovalRequestStatusType.Rejected.ToString() },
                new ApprovalRequestStatus { ID = 4, StatusType = ApprovalRequestStatusType.Cancelled, Description = ApprovalRequestStatusType.Cancelled.ToString() }
            );

            // Seed data for project types
            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType { ID = 1, Name = "Internal" },
                new ProjectType { ID = 2, Name = "Client" }
            );

            // Seed data for project statuses
            modelBuilder.Entity<ProjectStatus>().HasData(
                new ProjectStatus { ID = 1, StatusType = ProjectStatusType.Active },
                new ProjectStatus { ID = 2, StatusType = ProjectStatusType.Inactive }
            );

            // Seed data for projects
            modelBuilder.Entity<Project>().HasData(
                new Project { ID = 1, ProjectTypeID = 1, StartDate = new DateTime(2023, 1, 10), ProjectManagerID = 3, Comment = "Internal project for HR system", StatusID = 1 },
                new Project { ID = 2, ProjectTypeID = 2, StartDate = new DateTime(2023, 2, 15), ProjectManagerID = 3, Comment = "Client project for ABC Inc.", StatusID = 1 },
                new Project { ID = 3, ProjectTypeID = 1, StartDate = new DateTime(2023, 3, 20), ProjectManagerID = 3, Comment = "Research project", StatusID = 1 },
                new Project { ID = 4, ProjectTypeID = 2, StartDate = new DateTime(2023, 4, 5), ProjectManagerID = 3, Comment = "Marketing campaign", StatusID = 1 },
                new Project { ID = 5, ProjectTypeID = 1, StartDate = new DateTime(2023, 5, 10), ProjectManagerID = 3, Comment = "IT infrastructure upgrade", StatusID = 1 },
                new Project { ID = 6, ProjectTypeID = 2, StartDate = new DateTime(2023, 6, 15), ProjectManagerID = 3, Comment = "Client project for XYZ Corp.", StatusID = 1 },
                new Project { ID = 7, ProjectTypeID = 1, StartDate = new DateTime(2023, 7, 20), ProjectManagerID = 3, Comment = "Research and development", StatusID = 1 }
            );

            modelBuilder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee { ID = 1, ProjectID = 1, EmployeeID = 1 },
                new ProjectEmployee { ID = 2, ProjectID = 1, EmployeeID = 2 },
                new ProjectEmployee { ID = 3, ProjectID = 2, EmployeeID = 2 },
                new ProjectEmployee { ID = 4, ProjectID = 2, EmployeeID = 3 },
                new ProjectEmployee { ID = 5, ProjectID = 3, EmployeeID = 3 },
                new ProjectEmployee { ID = 6, ProjectID = 3, EmployeeID = 4 },
                new ProjectEmployee { ID = 7, ProjectID = 4, EmployeeID = 4 },
                new ProjectEmployee { ID = 8, ProjectID = 4, EmployeeID = 5 },
                new ProjectEmployee { ID = 9, ProjectID = 5, EmployeeID = 5 },
                new ProjectEmployee { ID = 10, ProjectID = 5, EmployeeID = 6 }
            );
        }

        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        // Loading custom attribute enum names
        public static string GetDisplayName(Enum value)
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            if (memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(EnumDisplayNameAttribute), false);
                if (attributes.Length > 0)
                {
                    return ((EnumDisplayNameAttribute)attributes[0]).DisplayName;
                }
            }
            return value.ToString();
        }
    }
}
