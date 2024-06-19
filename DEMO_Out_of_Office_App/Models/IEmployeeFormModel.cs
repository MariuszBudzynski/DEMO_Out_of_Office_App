using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.DTOS;

namespace DEMOOutOfOfficeApp.Models
{
	public interface IEmployeeFormModel
	{
        public int ID { get; set; }
        public Employee Employee { get; set; }
        public List<Subdivision> Subdivisions { get; set; }
        public List<EmployeeStatus> Statuses { get; set; }
        public IFormFile Photo { get; set; }
        public List<PeoplePartnerDTO> PeoplePartner { get; set; }
		public List<Role> Roles { get; set; }
	}
}
