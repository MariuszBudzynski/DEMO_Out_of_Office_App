using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class ApprovalRequestStatus : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public EmployeeStatus StatusType { get; set; }

        [Required]
        public int StatusTypeID { get; set; }
        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
	}
}
