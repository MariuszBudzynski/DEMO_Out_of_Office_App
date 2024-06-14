using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EmployeesModel : PageModel
    {
        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;

        [BindProperty(SupportsGet = true)]
        public List<EmployeeDTO> Employees { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
        }
        public async Task OnGetAsync()
        {
            Employees = await FetchEmployeesAsync();
            //await LoadEmployees();
        }

        //private async Task  LoadEmployees()
        //{
           

        //}

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

        //private void DeactivateEmployee(int id)
        //{
        //    // Logika dezaktywacji pracownika
        //    //var employee = Employees.FirstOrDefault(e => e.ID == id);
        //    //if (employee != null)
        //    //{
        //    //   /* employee.Status = "Inactive"*/;
        //    //}
        //}

    }
}
