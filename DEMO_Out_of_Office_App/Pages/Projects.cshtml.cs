using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "EmployeeHRPMAdminPolicy")]
    public class ProjectsModel : PageModel
    {
        private readonly DataLoaderHelper _dataLoaderHelper;

        [BindProperty(SupportsGet = true)]
        public List<ProjectDTO>? Projects { get; set; }
        public ProjectsModel(DataLoaderHelper dataLoaderHelper)
        {
            _dataLoaderHelper = dataLoaderHelper;
        }
        public async Task OnGetAsync()
        {
            // use claims
            var employeeId = int.Parse(User.FindFirstValue("EmployeeID"));

            Projects = await _dataLoaderHelper.LoadProjectsDTOAsync();
        }
    }
}