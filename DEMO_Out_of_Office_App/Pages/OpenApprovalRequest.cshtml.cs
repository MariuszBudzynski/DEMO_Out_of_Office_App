using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
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
        private readonly IUpdateAprovalRequestUseCase _updateAprovalRequestUseCase;

        [BindProperty(SupportsGet =true)]
        public AprovalRequestDTO ApprovalRequest { get; set; }

        [BindProperty(SupportsGet = true)]
        public int AprovalRequestID { get; set; }

        [BindProperty]
        public string AprovalType { get; set; }
   
        public OpenApprovalRequestModel(IDataLoaderHelper dataLoaderHelper,
                                        IUpdateAprovalRequestUseCase updateAprovalRequestUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;

            _updateAprovalRequestUseCase = updateAprovalRequestUseCase;
        }

        public async Task OnGetAsync(int id)
        {
            AprovalRequestID = id;
            ApprovalRequest = await CreateAprovalResultAsync(id);

        }

        public async Task<IActionResult> OnPostApproveAsync()
        {
            var aprovalRequest = await LoadApprovalRequestByIdAsync(AprovalRequestID);

           await  UpdateApprovalRequestAsync(aprovalRequest);

            AprovalType = String.Empty;

            return RedirectToPage("/ApprovalRequests");
        }

        public async Task<IActionResult> OnPostRejectAsync()
        {
            var aprovalRequest = await LoadApprovalRequestByIdAsync(AprovalRequestID);

            await UpdateApprovalRequestAsync(aprovalRequest);

            AprovalType = String.Empty;

            return RedirectToPage("/ApprovalRequests");
        }

    
        private async Task<ApprovalRequest> LoadApprovalRequestByIdAsync(int id)
        {
            return await _dataLoaderHelper.LoadAprovalRequestAsync(id);
        }

        private async Task UpdateApprovalRequestAsync(ApprovalRequest approvalRequest)
        {
            var employeeIdInt = 0;

            var claims = HttpContext.User.Claims.ToList();

            var employeeIdClaim = claims.FirstOrDefault(c => c.Type == "EmployeeID");

            if (employeeIdClaim != null)
            {
                string employeeId = employeeIdClaim.Value;
                employeeIdInt = int.Parse(employeeId);
                approvalRequest.ApproverID = employeeIdInt;
            }
            else
            {
                approvalRequest.ApproverID = 0; 
            }

            var fullAproverName = (await _dataLoaderHelper.LoadAllUsersAsync()).FirstOrDefault(u=> u.EmployeeID == employeeIdInt).FullName;

            approvalRequest.StatusID = (int)GetApprovalStatusType(AprovalType);
            approvalRequest.Comment = ApprovalRequest.Comment;

            await _updateAprovalRequestUseCase.ExecuteAsync(approvalRequest);
        }

        private ApprovalRequestStatusType GetApprovalStatusType(string approvalType)
        {
            switch (approvalType)
            {
                case "Approve":
                    return ApprovalRequestStatusType.Approved;
                case "Reject":
                    return ApprovalRequestStatusType.Rejected;
                default:
                    throw new ArgumentException("Unknown approval type", nameof(approvalType));
            }
        }

        private async Task<AprovalRequestDTO> CreateAprovalResultAsync(int id)
        {

            var aprovalRequest = await LoadApprovalRequestByIdAsync(id);

            var absenceReason = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).FirstOrDefault(ar=> ar.ID == aprovalRequest.LeaveRequestID);

            var leaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).FirstOrDefault(lr=> lr.ID == aprovalRequest.LeaveRequestID);

            var aprovalRequestDTO = new AprovalRequestDTO(

                aprovalRequest.ID,
                aprovalRequest.ApprovalRequestStatus.Description,
                leaveRequest.Comment,
                0,
                leaveRequest.ID,
                absenceReason.Name,
                leaveRequest.Comment
             );

            return aprovalRequestDTO;
        }


    }
}
