using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class LeaveRequestsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
