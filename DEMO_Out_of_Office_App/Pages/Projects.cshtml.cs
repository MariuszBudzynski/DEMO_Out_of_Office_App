using DEMOOutOfOfficeApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class ProjectsModel : PageModel
    {
        public async Task OnGetAsync()
        {
            // use claims
            var employeeId = int.Parse(User.FindFirstValue("EmployeeID"));

        }
    }
}
