namespace DEMOOutOfOfficeApp.Pages
{
    public class AddProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveDataUseCase _saveDataUseCase;

        [BindProperty(SupportsGet = true)]
        public ProjectDTO Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectType> ProjectTypes { get; set; } = new List<ProjectType>();

        [BindProperty(SupportsGet = true)]
        public int ProjectTypeID { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProjectManagerId { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<User> ProjectManagers { get; set; }

        public AddProjectModel(IDataLoaderHelper dataLoaderHelper, ISaveDataUseCase saveDataUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveDataUseCase = saveDataUseCase;
        }

        public async Task OnGetAsync(int id)
        {
            try
            {
                ProjectTypes = (await _dataLoaderHelper.LoadProjectTypesAsync()).ToList();
                Project = new ProjectDTO(id = 0, "", DateTime.Now, DateTime.Now, "", 0, "", "", "New");
                ProjectManagers = (await _dataLoaderHelper.LoadAllUsersAsync()).Where(pm => pm.RoleID == (int)UserRole.ProjectManager).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnGetAsync method.");
                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await CreateAndSaveNewProject();
                return RedirectToPage("/Projects");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnPostAsync method.");
                throw;
            }
        }

        private async Task CreateAndSaveNewProject()
        {
            try
            {
                var project = new Project()
                {
                    ProjectTypeID = ProjectTypeID,
                    StartDate = Project.StartDate,
                    EndDate = Project.EndDate,
                    ProjectManagerID = ProjectManagerId,
                    Comment = Project.Comment,
                    StatusID = 1
                };

                await _saveDataUseCase.ExecuteAsync<Project>(project);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in CreateAndSaveNewProject method.");
                throw;
            }
        }
    }
}
