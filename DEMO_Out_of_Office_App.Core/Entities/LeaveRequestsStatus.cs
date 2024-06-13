using DEMOOutOfOfficeApp.Common;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class LeaveRequestsStatus : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public EmployeeStatus StatusType { get; set; }

		public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
	}
}
