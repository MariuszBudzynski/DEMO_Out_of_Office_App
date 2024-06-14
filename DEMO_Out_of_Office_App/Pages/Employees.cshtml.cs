using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EmployeesModel : PageModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [BindProperty(SupportsGet = true)]
        public string NameSort { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Request.Form.ContainsKey("add"))
            {
                return RedirectToPage("./AddEmployee");
            }
            if (Request.Form.ContainsKey("edit"))
            {
                var id = int.Parse(Request.Form["edit"]);
                return RedirectToPage("./EditEmployee", new { id });
            }
            if (Request.Form.ContainsKey("deactivate"))
            {
                var id = int.Parse(Request.Form["deactivate"]);
                DeactivateEmployee(id);
            }

            LoadEmployees();
            return Page();
        }

        private void LoadEmployees()
        {
            // Przyk³adowe dane, docelowo pobierane z bazy danych
            Employees = new List<EmployeeViewModel>
            {
                new EmployeeViewModel { ID = 1, FullName = "John Doe", Position = "Software Engineer", Status = "Active" },
                new EmployeeViewModel { ID = 2, FullName = "Jane Smith", Position = "HR Specialist", Status = "Active" },
                new EmployeeViewModel { ID = 3, FullName = "Alice Johnson", Position = "Project Manager", Status = "Inactive" }
            };

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
            var employee = Employees.FirstOrDefault(e => e.ID == id);
            if (employee != null)
            {
                employee.Status = "Inactive";
            }
        }

        public class EmployeeViewModel
        {
            public int ID { get; set; }
            public string FullName { get; set; }
            public string Position { get; set; }
            public string Status { get; set; }
        }
    }
}

