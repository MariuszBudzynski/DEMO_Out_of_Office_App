using DEMOOutOfOfficeApp.Common;
using System.ComponentModel.DataAnnotations;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class Subdivision : IEntityId
	{
		[Key]
		public int ID { get; set; }
		[Required]
		public string Name { get; set; }

		public virtual ICollection<Employee> Employees { get; set; }
	}

}
