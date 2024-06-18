using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class Employee : IEntityId,IFullName, ISubdivision, IPosition, IStatus, IPeoplePartner, IOutOfOfficeBalance, IPhoto
    {
		[Key]
		public int ID { get; set; }

		[Required]
		public string? FullName { get; set; }

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
		public int PeoplePartnerID { get; set; }

		[Required]
		public decimal OutOfOfficeBalance { get; set; }

		public byte[]? Photo { get; set; }

		public  Subdivision? Subdivision { get; set; }
		public  Position? Position { get; set; }
		public EmployeeStatus? Status { get; set; }
		public  ICollection<ApprovalRequest>? ApprovalRequests { get; set; }
		public  ICollection<LeaveRequest>? LeaveRequests { get; set; }

        public virtual User? User { get; set; }

    }
}
