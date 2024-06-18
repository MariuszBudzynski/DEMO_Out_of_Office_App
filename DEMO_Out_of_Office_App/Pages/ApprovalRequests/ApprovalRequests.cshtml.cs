using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages.ApprovalRequests
{
    [Authorize(Policy = "HRPMAdminPolicy")]
    public class ApprovalRequestsModel : PageModel
    {
        private readonly IGetAprovalRequestsUseCase _getAprovalRequestsUseCase;

        [BindProperty(SupportsGet = true)]
        public List<AprovalRequestDTO> ApprovalRequests { get; set; }

        public ApprovalRequestsModel(IGetAprovalRequestsUseCase getAprovalRequestsUseCase)
        {
            _getAprovalRequestsUseCase = getAprovalRequestsUseCase;
        }

        public async Task OnGetAsync()
        {
            ApprovalRequests = await FetchApprovalRequestsAsync();
        }

        public IActionResult OnPostOpen()
        {
            return RedirectToPage("OpenApprovalRequest");
        }

        private async Task<List<AprovalRequestDTO>> FetchApprovalRequestsAsync()
        {
            var approvalRequests = await _getAprovalRequestsUseCase.ExecuteAsync();

            var approvalRequestsDTO = approvalRequests.Select(e => new AprovalRequestDTO(
                e.ID,
                e.Approver.FullName,
                e.LeaveRequest.ID,
                e.ApprovalRequestStatus.Description,
                e.Comment
                )).ToList();

            return approvalRequestsDTO;
        }
    }
}
