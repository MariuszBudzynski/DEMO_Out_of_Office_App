namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenLeaveRequestModel : PageModel
    {
        private int _id;
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IUpdateLeaveRequestUseCase _updateLeaveRequestUseCase;
        private readonly IUpdateAprovalRequestUseCase _updateApprovalRequestUseCase;

        public LeaveRequestDTO? LeaveRequestDTO { get; set; }

        public OpenLeaveRequestModel(IDataLoaderHelper dataLoaderHelper,
                                    IGetDataByIdUseCase getDataByIdUseCase,
                                    IUpdateLeaveRequestUseCase updateLeaveRequestUseCase,
                                    IUpdateAprovalRequestUseCase updateApprovalRequestUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _getDataByIdUseCase = getDataByIdUseCase;
            _updateLeaveRequestUseCase = updateLeaveRequestUseCase;
            _updateApprovalRequestUseCase = updateApprovalRequestUseCase;
        }

        public async Task OnGet(int id)
        {
            _id = id;
            try
            {
                await LoadLeaveRequest();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while loading leave request details for ID {LeaveRequestId}.", id);
                throw;
            }
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            try
            {
                var leaveRequest = await _getDataByIdUseCase.ExecuteAsync<LeaveRequest>(id);
                var approvalRequest = await _getDataByIdUseCase.ExecuteAsync<ApprovalRequest>(id);

                if (leaveRequest == null || approvalRequest == null)
                {
                    return NotFound();
                }

                leaveRequest.StatusType = LeaveRequestsStatusType.Cancelled;
                approvalRequest.StatusID = (int)ApprovalRequestStatusType.Cancelled;

                await _updateLeaveRequestUseCase.ExecureAsync(leaveRequest);
                await _updateApprovalRequestUseCase.ExecuteAsync(approvalRequest);

                return RedirectToPage("LeaveRequests");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while processing cancellation for leave request ID {LeaveRequestId}.", id);
                throw;
            }
        }

        public async Task LoadLeaveRequest()
        {
            try
            {
                var leaveRequest = (await _dataLoaderHelper.LoadLeaveRequestsDTOAsync()).FirstOrDefault(e => e.EmployeeId == _id);
                LeaveRequestDTO = leaveRequest;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while loading leave request details for employee ID {_id}.", _id);
                throw;
            }
        }
    }
}