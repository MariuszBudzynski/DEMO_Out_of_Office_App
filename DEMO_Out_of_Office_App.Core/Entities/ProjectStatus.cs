using DEMOOutOfOfficeApp.Common;
using DEMOOutOfOfficeApp.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class ProjectStatus : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public EmployeeStatus StatusType { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
	}
}
