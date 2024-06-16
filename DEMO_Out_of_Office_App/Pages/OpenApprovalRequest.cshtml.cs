using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenApprovalRequestModel : PageModel, IApprovalRequestsFormModel
	{
		[BindProperty]
		public ApprovalRequest ApprovalRequest { get; set; }
		public int ID { get; set; }
		public List<Employee> Approver { get; set; } = new List<Employee>();
		public List<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
		public List<ApprovalRequestStatus> Status { get; set; } = new List<ApprovalRequestStatus>();
		public string Comment { get; set; }
		public void OnGet()
        {
        }
    }
}
