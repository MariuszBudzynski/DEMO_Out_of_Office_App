using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class ApprovalRequestStatus : IEntityId
	{
        [Key]
        public int ID { get; set; }

        [Required]
        public ApprovalRequestStatusType StatusType { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
    }
}
