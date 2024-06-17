using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class LeaveRequestsModel : PageModel
    {
        private readonly DataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet =true)]
        public List<LeaveRequestDTO> LeaveRequests { get; set; }

        public LeaveRequestsModel(DataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }
        public async Task OnGetAsync()
        {
            int employeeId = GetEmployeeIdFromClaims();

            LeaveRequests = await _dataLoaderHelper.LoadLeaveRequestsDTOAsync(employeeId);
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

        public IActionResult OnPostOpenLeaveRequest(int id)
        {
            return RedirectToPage("/OpenLeaveRequest", new { id = id });
        }
        public IActionResult OnPostEditLeaveReques(int id)
        {
            return RedirectToPage("/EditLeaveRequest", new { id = id });
        }
    }
}