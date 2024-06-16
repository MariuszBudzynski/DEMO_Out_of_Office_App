using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class LeaveRequestsStatus : IEntityId
	{
        [Key]
        [Required]
        public LeaveRequestsStatusType StatusType { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }

        [NotMapped]
        public int ID { get; set; }
    }
}
