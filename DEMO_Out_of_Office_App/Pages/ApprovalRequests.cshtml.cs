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

        public IActionResult OnPostOpen()
        {
            return RedirectToPage("OpenApprovalRequest");
        }

        private async Task<List<AprovalRequestDTO>> FetchApprovalRequestsAsync() // move to DataLoaded 
        {
            List<AprovalRequestDTO> AprovalRequestsDTO = new();

            var approvalRequests = await _getAprovalRequestsUseCase.ExecuteAsync();

            var users = await  _dataLoaderHelper.LoadAllUsersAsync();

            foreach (var request in approvalRequests)
            {
                var HrUser = users.FirstOrDefault(u => u.EmployeeID == request.ApprovalRequestExtended.HrManagerId);
                var PmUser = users.FirstOrDefault(u => u.EmployeeID == request.ApprovalRequestExtended.PmManagerId);


                var AprovalRequessDTO =  new AprovalRequestDTO(
                    request.ID,
                    request.ApproverID,
                    request.LeaveRequestID,
                    request.ApprovalRequestExtended.EmployeeId,
                    HrUser.EmployeeID,
                    HrUser.FullName,
                    PmUser.EmployeeID,
                    PmUser.FullName,
                    request.ApprovalRequestStatus.Description,
                    request.Comment
                    );

                AprovalRequestsDTO.Add(AprovalRequessDTO);

            }

            return AprovalRequestsDTO;

            
        }
    }
}
