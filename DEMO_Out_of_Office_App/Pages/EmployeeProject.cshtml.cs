using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            await GetProjectEmployeeDTO(id);

            Projectts = (await _dataLoaderHelper.LoadAsllProjectsAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var rojectEmployee = CreateProjectEmployee(ProjectEmployeeDTO);

           await AddProjectEmployee(rojectEmployee);

            return RedirectToPage("/Employees"); 
        }

        private async Task GetProjectEmployeeDTO(int id)
        {
            var employeeProjects = (await _dataLoaderHelper.LoadEmployeeProjects()).FirstOrDefault(ep=> ep.EmployeeID == id);

            var projects = await _dataLoaderHelper.LoadProjectByIDAsync(employeeProjects.ProjectID);

            var employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(employeeProjects.EmployeeID);

            ProjectEmployeeDTO = CreateEmployeeDTO(employeeProjects, projects, employee);
        }

        private ProjectEmployeeDTO CreateEmployeeDTO(ProjectEmployee projectEmployee , Project project , Employee employee)
        {
            return new ProjectEmployeeDTO(employee.ID,project.ID,employee.FullName,project.Comment);

        }

        private async Task AddProjectEmployee(ProjectEmployee projectEmployee)
        {
            await _saveOrUpdateProjectEmployeeUseCase.ExecuteAsync(projectEmployee);
        }

        private ProjectEmployee CreateProjectEmployee(ProjectEmployeeDTO projectEmployeeDTO)
        {
            return new ProjectEmployee() { ProjectID = projectEmployeeDTO.ProjectId, EmployeeID = projectEmployeeDTO .EmployeeId};
        }
    }
}
