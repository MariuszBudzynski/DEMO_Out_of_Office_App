using DEMOOutOfOfficeApp.Common;
using DEMOOutOfOfficeApp.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class EmployeeStatus : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public Status StatusId { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
	}
}
