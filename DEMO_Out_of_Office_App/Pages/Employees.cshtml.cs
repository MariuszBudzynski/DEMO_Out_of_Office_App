using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Context;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "HRPMAdminPolicy")]
    public class EmployeesModel : PageModel
    {
        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IUpdateEmployeeUseCase _updateEmployeeUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private IEnumerable<User> usersHRManagerROle;

        [BindProperty(SupportsGet = true)]
        public List<EmployeeDTO> Employees { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase,
                              IGetDataByIdUseCase getDataByIdUseCase,
                              IUpdateEmployeeUseCase updateEmployeeUseCase,
                              IGetAllUsersUseCase getAllUsersUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _updateEmployeeUseCase = updateEmployeeUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
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

            usersHRManagerROle = (await _getAllUsersUseCase.ExecuteAsync()).ToList().Where(e=>e.RoleID == (int)UserRole.HRManager);



            var employeeDTOs = employees.Select(e => new EmployeeDTO(
                e.ID,
                e.FullName,
                e.Subdivision.Name,
                e.Position.Name,
                e.Status.StatusDescription,
                MatchEmployeeName(usersHRManagerROle,e),
                e.OutOfOfficeBalance,
                e.Photo
            )).ToList();

            return employeeDTOs;
        }

        private string MatchEmployeeName(IEnumerable<User> usersHRManagerROle, Employee employe)
        {
            foreach (var user in usersHRManagerROle)
            {
                if (user.EmployeeID == employe.PeoplePartnerID)
                {
                    return employe.FullName;
                }
            }

            return String.Empty;
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
