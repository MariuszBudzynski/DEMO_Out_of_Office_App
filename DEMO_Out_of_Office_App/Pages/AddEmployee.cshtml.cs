using DEMOOutOfOfficeApp.Core.Entities;
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

        [BindProperty]
        public Employee Employee { get; set; }
        
        public List<Subdivision> Subdivisions { get; set; }
        public List<Position> Positions { get; set; }
        public List<Role> Roles { get; set; }
        public List<EmployeeStatus> Statuses { get; set; }


        public AddEmployeeModel(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
                                IGetAllPositionsUseCase getAllPositionsUseCase,
                                IGetAllRolesUseCase getAllRolesUse,
                                IGetAllStatusesUseCase getAllStatusesUseCase)
        {
            _getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
            _getAllPositionsUseCase = getAllPositionsUseCase;
            _getAllRolesUse = getAllRolesUse;
            _getAllStatusesUseCase = getAllStatusesUseCase;
        }
        public async Task OnGet()
        {
            await LoadSubdivisionsOptions();
            await LoadPositionsOptions();
            await LoadPeoplePartnerOptions();
            await LoadStatusessOptions();
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
