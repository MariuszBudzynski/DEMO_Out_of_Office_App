using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class ProjectsModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet = true)]
        public List<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();

        public ProjectsModel(IDataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }

        public async Task OnGetAsync()
        {
            int employeeId = GetEmployeeIdFromClaims();

            if (employeeId == 0)
            {
                Projects = (await _dataLoaderHelper.LoadProjectsDTOAsync()).ToList();
            }
            else
            {
                Projects = (await _dataLoaderHelper.LoadProjectsDTOAsync()).Where(ep=>ep.EmployeeId == employeeId).ToList();
            }

        }

        public IActionResult OnPostOpenProject(int projectID)
        {
            return RedirectToPage("/OpenProject", new { id = projectID });
        }

        private int GetEmployeeIdFromClaims()
        {
            var employeeIdClaim = User.FindFirstValue("EmployeeID");
            var userRoleClaim = User.FindFirstValue(ClaimTypes.Role);

            if (userRoleClaim == "Employee" && int.TryParse(employeeIdClaim, out int employeeId))
            {
                return employeeId;
            }

            return 0;
        }
    }
}
