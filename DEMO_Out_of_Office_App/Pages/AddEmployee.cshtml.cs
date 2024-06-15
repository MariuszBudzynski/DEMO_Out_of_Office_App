using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IGetAllSubdivisionsUseCase _getAllSubdivisionsUseCase;
        private readonly IGetAllPositionsUseCase _getAllPositionsUseCase;
        private readonly IGetAllRolesUseCase _getAllRolesUse;
        private readonly IGetAllStatusesUseCase _getAllStatusesUseCase;
        private readonly ISaveSingleEmployeeUseCase _saveSingleEmployeeUseCase;

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
        public List<Position> Positions { get; set; } = new List<Position>();
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<EmployeeStatus> Statuses { get; set; } = new List<EmployeeStatus>();


        public AddEmployeeModel(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
                                IGetAllPositionsUseCase getAllPositionsUseCase,
                                IGetAllRolesUseCase getAllRolesUse,
                                IGetAllStatusesUseCase getAllStatusesUseCase,
                                ISaveSingleEmployeeUseCase saveSingleEmployeeUseCase)
        {
            _getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
            _getAllPositionsUseCase = getAllPositionsUseCase;
            _getAllRolesUse = getAllRolesUse;
            _getAllStatusesUseCase = getAllStatusesUseCase;
            _saveSingleEmployeeUseCase = saveSingleEmployeeUseCase;
        }
        public async Task OnGet()
        {
            await LoadSubdivisionsOptions();
            await LoadPositionsOptions();
            await LoadPeoplePartnerOptions();
            await LoadStatusessOptions();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (Photo != null && Photo.Length > 0)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    await Photo.CopyToAsync(memoryStream);
                    Employee.Photo = memoryStream.ToArray();
                }
            }
            await _saveSingleEmployeeUseCase.ExecuteAsync(Employee);

            return RedirectToPage("/Employees");
        }


        private async Task LoadSubdivisionsOptions()
        {
            Subdivisions = (await _getAllSubdivisionsUseCase.ExecuteAsync()).ToList();
        }

        private async Task LoadPeoplePartnerOptions()
        {
            Roles = (await _getAllRolesUse.ExecuteAsync()).ToList();
        }

        private async Task LoadPositionsOptions()
        {
            Positions = (await _getAllPositionsUseCase.ExecuteAsync()).ToList();
        }

        private async Task LoadStatusessOptions()
        {
            Statuses = (await _getAllStatusesUseCase.ExecuteAsync()).ToList();
        }
    }
}
