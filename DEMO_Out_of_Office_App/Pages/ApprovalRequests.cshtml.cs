using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "HRPMAdminPolicy")]
    public class ApprovalRequestsModel : PageModel
    {
        private readonly IGetAprovalRequestsUseCase _getAprovalRequestsUseCase;
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet = true)]
        public List<AprovalRequestDTO> ApprovalRequests { get; set; }

        public ApprovalRequestsModel(IGetAprovalRequestsUseCase getAprovalRequestsUseCase,
                                     IDataLoaderHelper dataLoaderHelper)
        {
            _getAprovalRequestsUseCase = getAprovalRequestsUseCase;
            _dataLoaderHelper = dataLoaderHelper;
        }

        public async Task OnGetAsync()
        {
            ApprovalRequests = await FetchApprovalRequestsAsync();
        }

        public IActionResult OnPostOpen(int aprovalId)
        {
            return RedirectToPage("OpenApprovalRequest", new { id = aprovalId });
        }

        private async Task<List<AprovalRequestDTO>> FetchApprovalRequestsAsync()
        {
            List<AprovalRequestDTO> AprovalRequestsDTO = new();

            var approvalRequests = await _getAprovalRequestsUseCase.ExecuteAsync();

           
          
            foreach (var request in approvalRequests)
            {
                var absenceReason = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).FirstOrDefault(ar => ar.ID == request.LeaveRequestID);

                var leaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).FirstOrDefault(lr => lr.ID == request.LeaveRequestID);


                var AprovalRequessDTO = new AprovalRequestDTO(
                request.ID,
                request.ApprovalRequestStatus.Description,
                request.Comment,
                request.ApproverID ?? 0,
                request.LeaveRequestID ?? 0

                    );

                AprovalRequestsDTO.Add(AprovalRequessDTO);

            }

            return AprovalRequestsDTO;


        }

    }
}
