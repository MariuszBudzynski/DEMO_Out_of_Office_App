using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly IUpdateProjectDataUseCase _updateProjectDataUseCase;

        [BindProperty(SupportsGet = true)]
        public ProjectDTO Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectType> ProjectTypes { get; set; } = new ();

        [BindProperty(SupportsGet = true)]
        public int ProjectTypeID { get; set; }

        public OpenProjectModel(IDataLoaderHelper dataLoaderHelper,
                                IUpdateProjectDataUseCase updateProjectDataUseCase
            )
        {
            _dataLoaderHelper = dataLoaderHelper;
            _updateProjectDataUseCase = updateProjectDataUseCase;
        }


        public async Task OnGetAsync(int id)
        {
            Project = (await _dataLoaderHelper.LoadProjectsDTOAsync()).FirstOrDefault(p => p.Id == id);
            ProjectTypes = (await _dataLoaderHelper.LoadProjectTypesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostHandleForm(string submitType, int projectId)
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




        //public async Task<IActionResult> OnPostDeactivateProject(int projectId)
        //{
        //    var projectToDeactivate = await _dataLoaderHelper.LoadProjectByIDAsync(projectId);

        //    projectToDeactivate.StatusID = 2;

        //    await _updateProjectDataUseCase.ExecuteAsync(projectToDeactivate);


        //    return RedirectToPage("/Projects");
        //}


        //public async Task<IActionResult> OnPostSaveProject(int projectId)
        //{
        //    await CreateAndUpdateProject(projectId);
        //    return RedirectToPage("/Projects");
        //}

        private async Task CreateAndUpdateProject(int projectId)
        {
            //Project = (await _dataLoaderHelper.LoadProjectsDTOAsync()).FirstOrDefault(p => p.Id == projectId);
            var pmId = (await _dataLoaderHelper.LoadAllUsersAsync()).FirstOrDefault(u => u.FullName == Project.Projectmanager).ID;

            var project = new Project()
            {
                ID = projectId,
                ProjectTypeID = ProjectTypeID,
                StartDate = Project.StartDate,
                EndDate = Project.EndDate,
                ProjectManagerID = pmId,
                Comment = Project.Comment,
                StatusID = 1
            };

            await _updateProjectDataUseCase.ExecuteAsync(project);
        }

    }
}
