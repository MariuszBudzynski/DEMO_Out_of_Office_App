using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class AbsenceReason
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
	}

}
