using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Net.Sockets;

namespace DEMOOutOfOfficeApp.Pages.Employees
{
    public class EditEmployeeModel : PageModel, IEmployeeFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveSingleEmployeeUseCase _saveSingleEmployeeUseCase;
        private readonly IUpdateEmployeeUseCase _updateEmployeeUse;
        private IEnumerable<User> usersHRManagerROle;

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public int ID { get; set; }
        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
        public List<Position> Positions { get; set; } = new List<Position>();
        public List<EmployeeStatus> Statuses { get; set; } = new List<EmployeeStatus>();

        public List<PeoplePartnerDTO> PeoplePartner { get; set; } = new();

        public EditEmployeeModel(IDataLoaderHelper dataLoaderHelper,
                                ISaveSingleEmployeeUseCase saveSingleEmployeeUseCase,
                                IUpdateEmployeeUseCase updateEmployeeUse)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveSingleEmployeeUseCase = saveSingleEmployeeUseCase;
            _updateEmployeeUse = updateEmployeeUse;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(id);
            Subdivisions = (await _dataLoaderHelper.LoadSubdivisionsAsync()).ToList();
            Positions = (await _dataLoaderHelper.LoadPositionsAsync()).ToList();
            Statuses = (await _dataLoaderHelper.LoadStatusesAsync()).ToList();
            PeoplePartner = (await _dataLoaderHelper.GetListOfPeoplePartner()).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (Photo != null && Photo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Photo.CopyToAsync(memoryStream);
                    Employee.Photo = memoryStream.ToArray();
                }
            }

            await _updateEmployeeUse.ExecuteAsync(Employee);

            return RedirectToPage("/Employees");
        }
        private async Task<List<PeoplePartnerDTO>> GetListOfPeoplePartner()
        {
            usersHRManagerROle = (await _dataLoaderHelper.LoadAllUsersAsync()).ToList().Where(e => e.RoleID == (int)UserRole.HRManager);

            return usersHRManagerROle.Select(e => new PeoplePartnerDTO(
                e.ID,
                e.FullName
                )).ToList();


        }
    }
}
