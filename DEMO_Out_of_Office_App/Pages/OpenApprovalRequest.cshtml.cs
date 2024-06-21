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


    }
}
