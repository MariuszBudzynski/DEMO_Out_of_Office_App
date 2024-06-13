using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

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
		}










	}
}
