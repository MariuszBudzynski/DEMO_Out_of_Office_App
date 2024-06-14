using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class Role : IEntityId
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public UserRole UserRole { get; set; }
		[Required]
        public string UserRoleDescription { get; set; }

        [Required]
		public string DescriptionOfMainTasks { get; set; }
	}
}
