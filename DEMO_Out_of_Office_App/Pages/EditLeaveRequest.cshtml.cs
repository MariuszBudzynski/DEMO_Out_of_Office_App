namespace DEMOOutOfOfficeApp.Pages
{
    public class EditLeaveRequestModel : PageModel , ILeaveRequestFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IUpdateLeaveRequestUseCase _updateLeaveRequestUseCase;
        private readonly IGetLeaveRequestsUseCase _getLeaveRequestsUseCase;


        [BindProperty(SupportsGet = true)]
        public LeaveRequest LeaveRequest { get; set; }

        public List<AbsenceReason> AbsenceReasons { get; set; }

        public string FullName { get; set; }
        public string Status { get; set; }

        public EditLeaveRequestModel(IDataLoaderHelper dataLoaderHelper,
                                    IUpdateLeaveRequestUseCase updateLeaveRequestUseCase,                                   
                                    IGetLeaveRequestsUseCase getLeaveRequestsUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _updateLeaveRequestUseCase = updateLeaveRequestUseCase;
            _getLeaveRequestsUseCase = getLeaveRequestsUseCase;
        }

        public async Task OnGet(int id)
        {
            try
            {
                LeaveRequest = (await _dataLoaderHelper.LoadAllLeaveRequestAsync()).FirstOrDefault(lr => lr.ID == id);
                AbsenceReasons = (await _dataLoaderHelper.LoadAbsenceReasonAsync()).ToList();
                FullName = (await _dataLoaderHelper.LoadAllEmployeesAsync()).FirstOrDefault(e => e.ID == id).FullName;
                Status = await _dataLoaderHelper.LoadLeaveRequestStatusAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling GET request in EditLeaveRequestModel.");
                throw;
            }

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                LeaveRequest.StatusType = LeaveRequestsStatusType.New;

                await _updateLeaveRequestUseCase.ExecureAsync(LeaveRequest);

                return RedirectToPage("LeaveRequests");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling POST request in EditLeaveRequestModel.");
                throw;
            }
        }
    }
}
