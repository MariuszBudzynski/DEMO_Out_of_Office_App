using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class Subdivision
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
	}

}
