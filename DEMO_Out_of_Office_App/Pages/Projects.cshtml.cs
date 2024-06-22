namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class ProjectsModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet = true)]
        public List<ProjectDTO> Projects { get; set; } = new List<ProjectDTO>();

        public ProjectsModel(IDataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }

        public async Task OnGetAsync()
        {
            try
            {
                int employeeId = GetEmployeeIdFromClaims();

                if (employeeId == 0)
                {
                    Projects = (await _dataLoaderHelper.LoadProjectsDTOAsync()).ToList();
                }
                else
                {
                    Projects = (await _dataLoaderHelper.LoadProjectsDTOAsync()).Where(ep => ep.EmployeeId == employeeId).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while loading projects.");
                throw;
            }
        }

        public IActionResult OnPostOpenProject(int projectID)
        {
            try
            {
                return RedirectToPage("/OpenProject", new { id = projectID });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while redirecting to OpenProject.");
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
                Log.Error(ex, "An error occurred while extracting EmployeeID from claims.");
                throw;
            }
        }
    }
}
