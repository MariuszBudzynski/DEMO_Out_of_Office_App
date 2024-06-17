using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{   
    public class OpenLeaveRequestModel : PageModel
    {
        private int _id;
        private readonly DataLoaderHelper _dataLoaderHelper;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IUpdateLeaveRequestUseCase _updateLeaveRequestUseCase;
        private readonly IUpdateAprovalRequestUseCase _updateAprovalRequestUseCase;

        public LeaveRequestDTO? LeaveRequestDTO { get; set; }
        public OpenLeaveRequestModel(DataLoaderHelper dataLoaderHelper,
                                    IGetDataByIdUseCase getDataByIdUseCase,
                                    IUpdateLeaveRequestUseCase updateLeaveRequestUseCase,
                                    IUpdateAprovalRequestUseCase updateAprovalRequestUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _getDataByIdUseCase = getDataByIdUseCase;
            _updateLeaveRequestUseCase = updateLeaveRequestUseCase;
            _updateAprovalRequestUseCase = updateAprovalRequestUseCase;
        }
        public async Task OnGet(int id)
        {
            _id = id;
            await LoadLeaveRequest();
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {

            var leaveRequest = await _getDataByIdUseCase.ExecuteAsync<LeaveRequest>(id);

            var approvalRequest = await _getDataByIdUseCase.ExecuteAsync<ApprovalRequest>(id);

            if (leaveRequest == null)
            {
                return NotFound();
            }

            leaveRequest.StatusType = LeaveRequestsStatusType.Cancelled;
            approvalRequest.StatusID = (int)ApprovalRequestStatusType.Cancelled;

            await _updateLeaveRequestUseCase.ExecureAsync(leaveRequest);
            await _updateAprovalRequestUseCase.ExecuteAsync(approvalRequest);

            return RedirectToPage("LeaveRequests");
        }

        public async Task LoadLeaveRequest()
        {
            var leaveRequests = (await _dataLoaderHelper.LoadLeaveRequestsDTOAsync()).FirstOrDefault(e=>e.Id==_id);
            LeaveRequestDTO = leaveRequests;

        }

    }
}
