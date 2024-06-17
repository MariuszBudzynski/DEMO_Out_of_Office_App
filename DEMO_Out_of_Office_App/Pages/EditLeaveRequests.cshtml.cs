using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EditLeaveRequestsModel : PageModel 
    {
        public LeaveRequest LeaveRequest { get; set; }

        public void OnGet()
        {
        }
    }
}
