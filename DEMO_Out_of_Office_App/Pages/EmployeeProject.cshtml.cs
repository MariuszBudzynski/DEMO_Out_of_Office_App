namespace DEMOOutOfOfficeApp.Pages
{
    public class EmployeeProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveOrUpdateProjectEmployeeUseCase _saveOrUpdateProjectEmployeeUseCase;

        [BindProperty(SupportsGet =true)]
        public ProjectEmployeeDTO ProjectEmployeeDTO { get; set; }

        public List<Project> Projectts { get; set; }

        public EmployeeProjectModel(IDataLoaderHelper dataLoaderHelper,
                                    ISaveOrUpdateProjectEmployeeUseCase saveOrUpdateProjectEmployeeUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveOrUpdateProjectEmployeeUseCase = saveOrUpdateProjectEmployeeUseCase;
        }

        public async Task OnGet(int id)
        {
            try
            {
                await GetProjectEmployeeDTO(id);

                Projectts = (await _dataLoaderHelper.LoadAsllProjectsAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling GET request in EmployeeProjectModel.");
                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var rojectEmployee = CreateProjectEmployee(ProjectEmployeeDTO);

                await AddProjectEmployee(rojectEmployee);

                return RedirectToPage("/Employees");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling POST request in EmployeeProjectModel.");
                throw;
            }
        }

        private async Task GetProjectEmployeeDTO(int id)
        {
           
            try
            {
                var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).FirstOrDefault(ep => ep.EmployeeID == id);

                var projects = await _dataLoaderHelper.LoadProjectByIDAsync(employeeProjects.ProjectID);

                var employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(employeeProjects.EmployeeID);

                ProjectEmployeeDTO = CreateEmployeeDTO(employeeProjects, projects, employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting ProjectEmployeeDTO in EmployeeProjectModel.");
                throw;
            }
        }

        private ProjectEmployeeDTO CreateEmployeeDTO(ProjectEmployee projectEmployee , Project project , Employee employee)
        {
            return new ProjectEmployeeDTO(employee.ID,project.ID,employee.FullName,project.Comment);

        }

        private async Task AddProjectEmployee(ProjectEmployee projectEmployee)
        {
            try
            {
                await _saveOrUpdateProjectEmployeeUseCase.ExecuteAsync(projectEmployee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while adding ProjectEmployee in EmployeeProjectModel.");
                throw;
            }
        }

        private ProjectEmployee CreateProjectEmployee(ProjectEmployeeDTO projectEmployeeDTO)
        {
            return new ProjectEmployee() { ProjectID = projectEmployeeDTO.ProjectId, EmployeeID = projectEmployeeDTO .EmployeeId};
        }
    }
}
