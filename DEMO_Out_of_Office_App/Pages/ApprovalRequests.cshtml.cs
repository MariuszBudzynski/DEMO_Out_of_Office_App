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
            try
            {
                ApprovalRequests = await FetchApprovalRequestsAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnGetAsync method.");
                throw;
            }
        }

        public IActionResult OnPostOpen(int aprovalId)
        {    
                return RedirectToPage("OpenApprovalRequest", new { id = aprovalId });
        }

        private async Task<List<AprovalRequestDTO>> FetchApprovalRequestsAsync()
        {
            List<AprovalRequestDTO> AprovalRequestsDTO = new();

            try
            {
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
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in FetchApprovalRequestsAsync method.");
                throw;
            }

            return AprovalRequestsDTO;
        }
    }
}
