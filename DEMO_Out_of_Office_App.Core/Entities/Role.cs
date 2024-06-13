using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Common;
using DEMOOutOfOfficeApp.Common.Enums;

namespace DEMOOutOfOfficeApp.Core.Entities
{
	public class Role : IEntityId
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public UserRole UserRole { get; set; }

		[Required]
		public string DescriptionOfMainTasks { get; set; }
	}
}
