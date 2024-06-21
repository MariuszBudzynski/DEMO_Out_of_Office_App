using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class AddProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveDataUseCase _saveDataUseCase;

        [BindProperty(SupportsGet = true)]
        public ProjectDTO Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectType> ProjectTypes { get; set; } = new();
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
            ProjectTypes = (await _dataLoaderHelper.LoadProjectTypesAsync()).ToList();
            Project = new ProjectDTO(id = 0,"",DateTime.Now,DateTime.Now,"",0,"","","New");
            ProjectManagers = (await _dataLoaderHelper.LoadAllUsersAsync()).Where(pm => pm.RoleID == (int)UserRole.ProjectManager).ToList();
        }

		public async Task<IActionResult> OnPostAsync()
		{
            await CreateAndSvaeNewProject();

            return RedirectToPage("/Projects");
		}

        private  async Task CreateAndSvaeNewProject()
        {
           

            var project =  new Project()
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
	}
}
