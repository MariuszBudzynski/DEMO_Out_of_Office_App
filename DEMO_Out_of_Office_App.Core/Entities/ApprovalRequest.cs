using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class ApprovalRequest : IEntityId
	{
        [Key]
        public int ID { get; set; }

        public int? LeaveRequestID { get; set; }

        [Required]
        [ForeignKey("ApprovalRequestStatus")]
        public int StatusID { get; set; }

        public string Comment { get; set; }

        public int EmployeeId { get; set; }
        
        public int? ApproverID { get; set; }

        public virtual LeaveRequest LeaveRequest { get; set; }
        public virtual ApprovalRequestStatus ApprovalRequestStatus { get; set; }
        public virtual User Aprover { get; set; }
    }
}
