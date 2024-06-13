using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DEMOOutOfOfficeApp.Core.Context
{
	internal class AppDbContext : DbContext
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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Role>().HasData(
				new Role { UserRole = UserRole.Employee, DescriptionOfMainTasks = "Creates a leave request" },
				new Role { UserRole = UserRole.HRManager, DescriptionOfMainTasks = "Manages the list of employees\n Approves/rejects requests" },
				new Role { UserRole = UserRole.ProjectManager, DescriptionOfMainTasks = "Manages the list of projects\n Approves/rejects requests" },
				new Role { UserRole = UserRole.Administrator, DescriptionOfMainTasks = "Grants access rights\n Manages all data" }		
			);
		}










	}
}
