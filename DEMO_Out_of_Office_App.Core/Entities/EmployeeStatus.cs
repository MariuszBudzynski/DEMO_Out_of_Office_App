using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class EmployeeStatus : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public Status StatusId { get; set; }
		[Required]
        public string StatusDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
	}
}
