using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class ProjectEmployee
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("Project")]
		public int ProjectID { get; set; }

		[Required]
		[ForeignKey("Employee")]
		public int EmployeeID { get; set; }

		public virtual Project Project { get; set; }
		public virtual Employee Employee { get; set; }
	}
}
