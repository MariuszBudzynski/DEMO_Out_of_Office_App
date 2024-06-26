﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.Entities
{
    public class Project : IEntityId
	{
		[Key]
		public int ID { get; set; }

		[Required]
		[ForeignKey("ProjectType")]
		public int ProjectTypeID { get; set; }

		[Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

		[Required]
		[ForeignKey("Employee")]
		public int ProjectManagerID { get; set; }

		public string Comment { get; set; }

        [Required]
        [ForeignKey("ProjectStatus")]
        public int StatusID { get; set; }

        public virtual ProjectType ProjectType { get; set; }
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual Employee ProjectManager { get; set; }
		public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }
	}
}