using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Services.SortingService;
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
        public string NameSort { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase,SortingService sortingService)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
            NameSort = sortingService.NameSort;
        }
        public async Task OnGetAsync()
        {
           await LoadEmployees();
        }

        public async Task<IActionResult> OnPost()
        {
            //await LoadEmployees();
            return Page();
        }

        private async Task  LoadEmployees()
        {
            Employees = (await _getAllEmployeesUseCase.ExecuteAsync())
                .Select(e => new EmployeeDTO(
                    e.ID,
                    e.FullName,
                    e.Subdivision.Name,
                    e.Position.Name,
                    e.Status.StatusDescription,
                    e.PeoplePartner.UserRoleDescription,
                    e.OutOfOfficeBalance,
                    e.Photo
                ))
                .ToList();

                if (NameSort == "name_desc")
                {
                    Employees = Employees.OrderByDescending(e => e.FullName).ToList();
                }
                else
                {
                    Employees = Employees.OrderBy(e => e.FullName).ToList();
                }
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

        public class EmployeeViewModel
        {
            public int ID { get; set; }
            public string? FullName { get; set; }
            public string? Subdivision { get; set; }
            public string? Position { get; set; }
            public string? Status { get; set; }
            public string? PeoplePartner { get; set; }

            public int OutOfOfficeBalance { get; set; }
            public string? Photo { get; set; }
        }

    }
}
