namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class LeaveRequestsModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet =true)]
        public List<LeaveRequestDTO> LeaveRequests { get; set; }

        public int EmployeeId { get; set; }

        public LeaveRequestsModel(IDataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }
        public async Task OnGetAsync()
        {
            try
            {
                int employeeId = GetEmployeeIdFromClaims();
                EmployeeId = employeeId;
                LeaveRequests = (await _dataLoaderHelper.LoadLeaveRequestsDTOAsync(employeeId)).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while loading leave requests.");
                throw;
            }
        }

        private int GetEmployeeIdFromClaims()
        {
            try
            {
                var employeeIdClaim = User.FindFirstValue("EmployeeID");
                var userRoleClaim = User.FindFirstValue(ClaimTypes.Role);

                if (userRoleClaim == "Employee" && int.TryParse(employeeIdClaim, out int employeeId))
                {
                    return employeeId;
                }

                return 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting employee ID from claims.");
                throw;
            }
        }

        public IActionResult OnPostOpenLeaveRequest(int id)
        {
            return RedirectToPage("/OpenLeaveRequest", new { id = id });
        }
        public IActionResult OnPostEditLeaveRequest(int id)
        {
            return RedirectToPage("/EditLeaveRequest", new { id = id });
        }

        public IActionResult OnPostAddLeaveRequest(int id)
        {
            return RedirectToPage("/AddLeaveRequest", new { id = id });
        }
    }
}
