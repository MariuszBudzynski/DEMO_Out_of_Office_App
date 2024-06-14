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

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortDirection { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
        }
        public async Task OnGetAsync()
        {
            if (string.IsNullOrEmpty(SortDirection))
            {
                SortDirection = "asc";
            }

            await LoadEmployees();

            //SortEmployees();
        }

        private void SortEmployees()
        {
            switch (SortBy)
            {
                case "FullName":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.FullName).ToList() : Employees.OrderByDescending(e => e.FullName).ToList();
                    break;
                case "SubdivisionName":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.SubdivisionName).ToList() : Employees.OrderByDescending(e => e.SubdivisionName).ToList();
                    break;
                case "PositionName":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.PositionName).ToList() : Employees.OrderByDescending(e => e.PositionName).ToList();
                    break;
                case "StatusName":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.StatusName).ToList() : Employees.OrderByDescending(e => e.StatusName).ToList();
                    break;
                case "PeoplePartnerName":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.PeoplePartnerName).ToList() : Employees.OrderByDescending(e => e.PeoplePartnerName).ToList();
                    break;
                case "OutOfOfficeBalance":
                    Employees = (SortDirection == "asc") ? Employees.OrderBy(e => e.OutOfOfficeBalance).ToList() : Employees.OrderByDescending(e => e.OutOfOfficeBalance).ToList();
                    break;
                default:
                    break;
            }
        }

        public async Task<IActionResult> OnPost()
        {
            return Page();
        }

        private async Task  LoadEmployees()
        {
            Employees = await FetchEmployeesAsync();

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

        private void DeactivateEmployee(int id)
        {
            // Logika dezaktywacji pracownika
            //var employee = Employees.FirstOrDefault(e => e.ID == id);
            //if (employee != null)
            //{
            //   /* employee.Status = "Inactive"*/;
            //}
        }

    }
}
