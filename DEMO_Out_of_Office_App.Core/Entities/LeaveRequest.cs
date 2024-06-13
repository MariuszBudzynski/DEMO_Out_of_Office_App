using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Common;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class LeaveRequest : IEntityId
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Employee")]
		public int EmployeeID { get; set; }

		[Required]
		[ForeignKey("AbsenceReason")]
		public int AbsenceReasonID { get; set; }

		[Required]
		public DateTime StartDate { get; set; }

		[Required]
		public DateTime EndDate { get; set; }

		public string Comment { get; set; }

		[Required]
		[ForeignKey("LeaveRequestsStatus")]
		public int StatusID { get; set; }

		public virtual Employee Employee { get; set; }
		public virtual AbsenceReason AbsenceReason { get; set; }
		public virtual LeaveRequestsStatus Status { get; set; }
	}
}
