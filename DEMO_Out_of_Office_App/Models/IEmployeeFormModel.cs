using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Models
{
	public interface IEmployeeFormModel
	{
        public Employee Employee { get; set; }

        public List<Subdivision> Subdivisions { get; set; }
        public List<Position> Positions { get; set; }
        public List<Role> Roles { get; set; }
        public List<EmployeeStatus> Statuses { get; set; }
        public IFormFile Photo { get; set; }
    }
}
