using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenApprovalRequestModel : PageModel
	{

        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;
        private readonly IGetLeaveRequestsUseCase _getLeaveRequestsUseCase;
        private readonly IGetDataUseCase _getDataUse;

        [BindProperty]
        public AprovalRequestDTO ApprovalRequest { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        public List<LeaveRequestsStatus> LeaveRequestsStatuses { get; set; } = new List<LeaveRequestsStatus>();

        public OpenApprovalRequestModel(
                            IGetAllEmployeesUseCase getAllEmployeesUseCase,
                            IGetLeaveRequestsUseCase getLeaveRequestsUseCase,
                            IGetDataUseCase getDataUse)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
            _getLeaveRequestsUseCase = getLeaveRequestsUseCase;
            _getDataUse = getDataUse;
        }

        public async Task OnGetAsync()
        {
            Employees = await FetchEmployeesAsync();
            LeaveRequests = await FetchLeaveRequest();
            LeaveRequestsStatuses = await FetchLeaveRequestsStatus();
        }


        private async Task<List<Employee>> FetchEmployeesAsync()
        {
            return (await _getAllEmployeesUseCase.ExecuteAsync()).ToList();

        }

        private async Task<List<LeaveRequest>> FetchLeaveRequest()
        {
            return (await _getLeaveRequestsUseCase.ExecuteAsync()).ToList();

        }

        private async Task<List<LeaveRequestsStatus>> FetchLeaveRequestsStatus()
        {
            return (await _getDataUse.ExecuteAsync<LeaveRequestsStatus>()).ToList();

        }
    }
}
