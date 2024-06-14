using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class Employee : IEntityId
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string FullName { get; set; }

		[Required]
		[ForeignKey("Subdivision")]
		public int SubdivisionID { get; set; }

		[Required]
		[ForeignKey("Position")]
		public int PositionID { get; set; }

		[Required]
		[ForeignKey("Status")]
		public int StatusID { get; set; }

		[Required]
		[ForeignKey("Role")]
		public int PeoplePartnerID { get; set; }

		[Required]
		public decimal OutOfOfficeBalance { get; set; }

		public string Photo { get; set; }

		public virtual Subdivision Subdivision { get; set; }
		public virtual Position Position { get; set; }
		public virtual EmployeeStatus Status { get; set; }
		public virtual Role PeoplePartner { get; set; }
		public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
		public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
	}
}
