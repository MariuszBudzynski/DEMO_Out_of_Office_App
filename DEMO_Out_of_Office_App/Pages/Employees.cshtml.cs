using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IUpdateEmployeeUseCase _updateEmployeeUseCase;

        [BindProperty(SupportsGet = true)]
        public List<EmployeeDTO> Employees { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase,
                              IGetDataByIdUseCase getDataByIdUseCase,
                              IUpdateEmployeeUseCase updateEmployeeUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _updateEmployeeUseCase = updateEmployeeUseCase;
        }
        public async Task OnGetAsync()
        {
            Employees = await FetchEmployeesAsync();
        }

        public async Task<IActionResult> OnPostDeactivateAsync(int employeeID)
        {
            var employee = await _getDataByIdUseCase.ExecuteAsync<Employee>(employeeID);
            if (employee != null)
            {
                employee.StatusID = (int)Status.Inactive;
                await _updateEmployeeUseCase.ExecuteAsync(employee);
            }

            Employees = await FetchEmployeesAsync();
            return RedirectToPage();
        }

        public IActionResult OnPostAdd()
        {
           return RedirectToPage("/AddEmployee");
        }

        public IActionResult OnPostEdit(int employeeID)
        {
			return RedirectToPage("/EditEmployee", new { id = employeeID });
		}

        private async Task<List<EmployeeDTO>> FetchEmployeesAsync()
        {
            var employees = await _getAllEmployeesUseCase.ExecuteAsync();

            var employeeDTOs = employees.Select(e => new EmployeeDTO(
                e.ID,
                e.FullName,
                e.Subdivision.Name,
                e.Position.Name,
                e.Status.StatusDescription,
                e.PeoplePartner.UserRoleDescription,
                e.OutOfOfficeBalance,
                e.Photo
            )).ToList();

            return employeeDTOs;
        }

        private async Task<Employee> ConvertToEmployee(EmployeeDTO employeeDTO)
        {
            var subdivision = await _getDataByIdUseCase.ExecuteAsync<Subdivision>(employeeDTO.ID);
            var position = await _getDataByIdUseCase.ExecuteAsync<Position>(employeeDTO.ID);
            var status = await _getDataByIdUseCase.ExecuteAsync<EmployeeStatus>(employeeDTO.ID);
            var role = await _getDataByIdUseCase.ExecuteAsync<Role>(employeeDTO.ID);



            return new Employee
            {
                ID = employeeDTO.ID,
                FullName = employeeDTO.FullName,
                SubdivisionID = subdivision.ID,
                PositionID = position.ID,
                StatusID = status.ID,
                PeoplePartnerID = role.ID,
                OutOfOfficeBalance = employeeDTO.OutOfOfficeBalance
            };
        }


    }
}
