namespace DEMOOutOfOfficeApp.Pages
{
    public class AddLeaveRequestModel : PageModel, ILeaveRequestFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveLeaveRequestDataUseCase _saveLeaveRequestDataUseCase;
        private readonly ISaveListOfObjectsToDatabaseUseCase _saveListOfObjectsToDatabaseUseCase;

        [BindProperty(SupportsGet = true)]
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }
        public ApprovalRequest ApprovalRequest { get; set; }
        public List<ApprovalRequest> ApprovalsRequest { get; set; } = new List<ApprovalRequest>();

        public AddLeaveRequestModel(IDataLoaderHelper dataLoaderHelper,
                                    ISaveLeaveRequestDataUseCase saveLeaveRequestDataUseCase,
                                    ISaveListOfObjectsToDatabaseUseCase saveListOfObjectsToDatabaseUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveLeaveRequestDataUseCase = saveLeaveRequestDataUseCase;
            _saveListOfObjectsToDatabaseUseCase = saveListOfObjectsToDatabaseUseCase;
        }

        public async Task OnGet(int id)
        {
            try
            {
                AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();

                LeaveRequest = new LeaveRequest() { EmployeeID = id, StatusType = LeaveRequestsStatusType.New, StartDate = DateTime.Now, EndDate = DateTime.Now, Comment = " " };

                FullName = (await _dataLoaderHelper.LoadAllEmployeesAsync()).FirstOrDefault(e => e.ID == id)?.FullName;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnGet method.");
                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                LeaveRequest.Comment = LeaveRequest.Comment ?? " ";
                LeaveRequest.StatusType = LeaveRequestsStatusType.New;

                await _saveLeaveRequestDataUseCase.ExecuteAsync(LeaveRequest);

                ApprovalsRequest = await CreateNewApprovalRequestList(LeaveRequest.ID);

                await _saveListOfObjectsToDatabaseUseCase.ExecuteAsync(ApprovalsRequest);

                return RedirectToPage("/LeaveRequests");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnPostAsync method.");
                throw;
            }
        }

        private async Task<List<ApprovalRequest>> CreateNewApprovalRequestList(int id)
        {
            try
            {
                var approvalList = new List<ApprovalRequest>();

                var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).Where(pe => pe.EmployeeID == id).ToList();

                var projectManagerIds = employeeProjects.Select(ep => ep.Project.ProjectManagerID).Distinct().ToList();

                foreach (var pm in projectManagerIds)
                {
                    var approvalRequest = new ApprovalRequest()
                    {
                        LeaveRequestID = LeaveRequest.ID,
                        StatusID = 1,
                        Comment = LeaveRequest.Comment ?? " ",
                        EmployeeId = id
                    };

                    approvalList.Add(approvalRequest);
                }

                return approvalList;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in CreateNewApprovalRequestList method.");
                throw;
            }
        }
    }
}
