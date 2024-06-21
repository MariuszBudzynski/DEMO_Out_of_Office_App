using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenApprovalRequestModel : PageModel
	{
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet =true)]
        public AprovalRequestDTO ApprovalRequest { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AprovalRequestID { get; set; }
        //public List<Employee> Employees { get; set; } = new List<Employee>();
        //public List<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
        //public List<LeaveRequestsStatus> LeaveRequestsStatuses { get; set; } = new List<LeaveRequestsStatus>();

        public OpenApprovalRequestModel(IDataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }

        public async Task OnGetAsync(int id)
        {
            ApprovalRequest = await CreateAprovalResultAsync(id);
            //Employees = await FetchEmployeesAsync();
            //LeaveRequests = await FetchLeaveRequest();
            //LeaveRequestsStatuses = await FetchLeaveRequestsStatus();
        }

        public async Task OnPostAsync()
        {
            //ApprovalRequest = await CreateAprovalResultAsync(AprovalRequestID);
        }

        private async Task<AprovalRequestDTO> CreateAprovalResultAsync(int id)
        {
            var aprovalRequest = await _dataLoaderHelper.LoadAprovalRequestAsync(id);


            var aprovalRequestDTO = new AprovalRequestDTO(
                
                aprovalRequest.ID,
                aprovalRequest.LeaveRequestID ?? 0,
                aprovalRequest.ApprovalRequestStatus.Description,
                aprovalRequest.Comment,
                aprovalRequest.ApproverID,
                aprovalRequest.RequestAproved,
                aprovalRequest.Aprover.FullName

             );

            return aprovalRequestDTO;
        }


        //private async Task<List<Employee>> FetchEmployeesAsync()
        //{
        //    return (await _getAllEmployeesUseCase.ExecuteAsync()).ToList();

        //}

        //private async Task<List<LeaveRequest>> FetchLeaveRequest()
        //{
        //    return (await _getLeaveRequestsUseCase.ExecuteAsync()).ToList();

        //}

        //private async Task<List<LeaveRequestsStatus>> FetchLeaveRequestsStatus()
        //{
        //    return (await _getDataUse.ExecuteAsync<LeaveRequestsStatus>()).ToList();

        //}
    }
}
