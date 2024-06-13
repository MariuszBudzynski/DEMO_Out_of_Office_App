using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DEMOOutOfOfficeApp.Core.Context
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions options) : base(options) {}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Subdivision> Subdivisions { get; set; }
		public DbSet<EmployeeStatus> Statuses { get; set; }
		public DbSet<ProjectType> ProjectTypes { get; set; }
		public DbSet<ProjectStatus> ProjectStatuses { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<LeaveRequestsStatus> LeaveRequestsStatuses { get; set; }
		public DbSet<LeaveRequest> LeaveRequests { get; set; }
		public DbSet<ApprovalRequestStatus> ApprovalRequestStatuses { get; set; }
		public DbSet<ApprovalRequest> ApprovalRequests { get; set; }
		public DbSet<AbsenceReason> AbsenceReasons { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<LeaveRequest>()
				.HasOne(lr => lr.Status)
				.WithMany(ls => ls.LeaveRequests)
				.HasForeignKey(lr => lr.StatusID)
				.OnDelete(DeleteBehavior.Restrict);

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

			modelBuilder.Entity<ApprovalRequest>()
			   .HasOne(ar => ar.Approver)
			   .WithMany(e => e.ApprovalRequests)
			   .HasForeignKey(ar => ar.ApproverID)
			   .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ApprovalRequest>()
				.HasOne(ar => ar.ApprovalRequestStatus)
				.WithMany(ars => ars.ApprovalRequests)
				.HasForeignKey(ar => ar.StatusID)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Role>().HasData(
				new Role { ID = 1,UserRole = UserRole.Employee, DescriptionOfMainTasks = "Creates a leave request" },
				new Role { ID = 2,UserRole = UserRole.HRManager, DescriptionOfMainTasks = "Manages the list of employees\n Approves/rejects requests" },
				new Role { ID = 3,UserRole = UserRole.ProjectManager, DescriptionOfMainTasks = "Manages the list of projects\n Approves/rejects requests" },
				new Role { ID = 4,UserRole = UserRole.Administrator, DescriptionOfMainTasks = "Grants access rights\n Manages all data" }		
			);

            modelBuilder.Entity<Subdivision>().HasData(
                new Subdivision { ID = 1, Name = "Finance" },
                new Subdivision { ID = 2, Name = "Human Resources" },
                new Subdivision { ID = 3, Name = "Research and Development" },
                new Subdivision { ID = 4, Name = "Marketing" }
            );

			modelBuilder.Entity<Position>().HasData(
                new Position { ID = 1, Name = "Software Engineer" },
                new Position { ID = 2, Name = "Project Manager" },
                new Position { ID = 3, Name = "HR Specialist" },
                new Position { ID = 4, Name = "Marketing Coordinator" }
            );

            modelBuilder.Entity<EmployeeStatus>().HasData(
               new EmployeeStatus { ID = 1, StatusId = Status.New },
               new EmployeeStatus { ID = 2, StatusId = Status.Active },
               new EmployeeStatus { ID = 3, StatusId = Status.Inactive }
           );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { ID = 1, FullName = "John Doe", SubdivisionID = 1, PositionID = 1, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 10.0m, Photo = "john_doe.jpg" },
                new Employee { ID = 2, FullName = "Jane Smith", SubdivisionID = 2, PositionID = 3, StatusID = 2, PeoplePartnerID = 2, OutOfOfficeBalance = 15.0m, Photo = "jane_smith.jpg" },
                new Employee { ID = 3, FullName = "Alice Johnson", SubdivisionID = 3, PositionID = 1, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 12.0m, Photo = "alice_johnson.jpg" },
                new Employee { ID = 4, FullName = "Bob Brown", SubdivisionID = 4, PositionID = 4, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 8.0m, Photo = "bob_brown.jpg" },
                new Employee { ID = 5, FullName = "Charlie Davis", SubdivisionID = 1, PositionID = 2, StatusID = 2, PeoplePartnerID = 3, OutOfOfficeBalance = 20.0m, Photo = "charlie_davis.jpg" },
                new Employee { ID = 6, FullName = "Diana Evans", SubdivisionID = 2, PositionID = 3, StatusID = 2, PeoplePartnerID = 1, OutOfOfficeBalance = 18.0m, Photo = "diana_evans.jpg" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { ID = 1, EmployeeID = 1, Username = "john.doe", PasswordHash = GetMd5Hash("password1") },
                new User { ID = 2, EmployeeID = 2, Username = "jane.smith", PasswordHash = GetMd5Hash("password2") },
                new User { ID = 3, EmployeeID = 3, Username = "alice.johnson", PasswordHash = GetMd5Hash("password3") },
                new User { ID = 4, EmployeeID = 4, Username = "bob.brown", PasswordHash = GetMd5Hash("password4") },
                new User { ID = 5, EmployeeID = 5, Username = "charlie.davis", PasswordHash = GetMd5Hash("password5") },
                new User { ID = 6, EmployeeID = 6, Username = "diana.evans", PasswordHash = GetMd5Hash("password6") }
            );

        }
        // A simple hash just for test data purposes
        private string GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

    }
}
