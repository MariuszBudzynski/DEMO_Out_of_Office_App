using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class ApprovalRequest
	{
		[Key]
		public int ID { get; set; }


		[Required]
		[ForeignKey("Approver")]
		public int ApproverID { get; set; }

		[Required]
		[ForeignKey("LeaveRequest")]
		public int LeaveRequestID { get; set; }

		[Required]
		[ForeignKey("ApprovalRequestStatus")]
		public int StatusID { get; set; }

		public string Comment { get; set; }

		public virtual LeaveRequest LeaveRequest { get; set; }
		public virtual ApprovalRequestStatus ApprovalRequestStatus { get; set; }
		public virtual Employee Approver { get; set; }
	}
}
