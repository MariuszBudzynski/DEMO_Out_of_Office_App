using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class ProjectType
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		public virtual ICollection<Project> Projects { get; set; }
	}
}
