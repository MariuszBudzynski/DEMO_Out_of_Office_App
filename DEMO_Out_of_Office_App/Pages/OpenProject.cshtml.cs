using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class OpenProjectModel : PageModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet = true)]
        public ProjectDTO Project { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<ProjectType> ProjectTypes { get; set; } = new ();

        public OpenProjectModel(IDataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;

        }


        public async Task OnGetAsync(int id)
        {
            Project = (await _dataLoaderHelper.LoadProjectsDTOAsync()).FirstOrDefault(p => p.Id == id);
            ProjectTypes = (await _dataLoaderHelper.LoadProjectTypesAsync()).ToList();
        }
    }
}
