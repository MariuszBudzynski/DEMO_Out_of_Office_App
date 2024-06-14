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

        [BindProperty(SupportsGet = true)]
        public List<EmployeeDTO> Employees { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        
        public string NameSort { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
        }
        public async Task OnGetAsync()
        {
           await LoadEmployees();
        }

        public IActionResult OnPost()
        {
            //if (Request.Form.ContainsKey("add"))
            //{
            //    return RedirectToPage("./AddEmployee");
            //}
            //if (Request.Form.ContainsKey("edit"))
            //{
            //    var id = int.Parse(Request.Form["edit"]);
            //    return RedirectToPage("./EditEmployee", new { id });
            //}
            //if (Request.Form.ContainsKey("deactivate"))
            //{
            //    var id = int.Parse(Request.Form["deactivate"]);
            //    DeactivateEmployee(id);
            //}

            //LoadEmployees();
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


            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Employees = Employees.Where(e => e.FullName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

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
