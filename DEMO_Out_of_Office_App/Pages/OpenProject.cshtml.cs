namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IUpdateProjectDataUseCase _updateProjectDataUseCase;

        [BindProperty(SupportsGet = true)]
        public ProjectDTO Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectType> ProjectTypes { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int ProjectTypeID { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<User> ProjectManagers { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ProjectManagerId { get; set; }

        public OpenProjectModel(IDataLoaderHelper dataLoaderHelper,
                                IUpdateProjectDataUseCase updateProjectDataUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _updateProjectDataUseCase = updateProjectDataUseCase;
        }

        public async Task OnGetAsync(int id)
        {
            try
            {
                Project = (await _dataLoaderHelper.LoadProjectsDTOAsync()).FirstOrDefault(p => p.Id == id);
                ProjectTypes = (await _dataLoaderHelper.LoadProjectTypesAsync()).ToList();
                ProjectManagers = (await _dataLoaderHelper.LoadAllUsersAsync()).Where(pm => pm.RoleID == (int)UserRole.ProjectManager).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while loading project details for project ID {ProjectId}.", id);
                throw;
            }
        }

        public async Task<IActionResult> OnPostHandleForm(string submitType, int projectId)
        {
            try
            {
                if (submitType == "Deactivate")
                {
                    var projectToDeactivate = await _dataLoaderHelper.LoadProjectByIDAsync(projectId);
                    projectToDeactivate.StatusID = 2;
                    await _updateProjectDataUseCase.ExecuteAsync(projectToDeactivate);
                }
                else if (submitType == "Save")
                {
                    await CreateAndUpdateProject(projectId);
                }

                return RedirectToPage("/Projects");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling form submission for project ID {ProjectId}.", projectId);
                throw;
            }
        }

        private async Task CreateAndUpdateProject(int projectId)
        {
            try
            {
                var project = new Project()
                {
                    ID = projectId,
                    ProjectTypeID = ProjectTypeID,
                    StartDate = Project.StartDate,
                    EndDate = Project.EndDate,
                    ProjectManagerID = ProjectManagerId,
                    Comment = Project.Comment,
                };

                await _updateProjectDataUseCase.ExecuteAsync(project);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while creating or updating project with ID {ProjectId}.", projectId);
                throw;
            }
        }
    }
}
