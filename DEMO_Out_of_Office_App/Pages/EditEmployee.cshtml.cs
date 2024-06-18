using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using DEMOOutOfOfficeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DEMOOutOfOfficeApp.Pages
{
    public class EditEmployeeModel : PageModel , IEmployeeFormModel
	{
		private readonly IDataLoaderHelper _dataLoaderHelper;
		private readonly ISaveSingleEmployeeUseCase _saveSingleEmployeeUseCase;
		private readonly IUpdateEmployeeUseCase _updateEmployeeUse;

		[BindProperty]
		public Employee Employee { get; set; }

		[BindProperty]
		public IFormFile Photo { get; set; }
        public int ID { get; set; }
        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
		public List<Position> Positions { get; set; } = new List<Position>();
		public List<Role> Roles { get; set; } = new List<Role>();
		public List<EmployeeStatus> Statuses { get; set; } = new List<EmployeeStatus>();

		public EditEmployeeModel(IDataLoaderHelper dataLoaderHelper,
								ISaveSingleEmployeeUseCase saveSingleEmployeeUseCase,
								IUpdateEmployeeUseCase updateEmployeeUse)
		{
			_dataLoaderHelper = dataLoaderHelper;
			_saveSingleEmployeeUseCase = saveSingleEmployeeUseCase;
			_updateEmployeeUse = updateEmployeeUse;
		}
		public async Task<IActionResult> OnGetAsync(int id)
		{
			Employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(id);
			Subdivisions = (await _dataLoaderHelper.LoadSubdivisionsAsync()).ToList();
			Roles = (await _dataLoaderHelper.LoadRolesAsync()).ToList();
			Positions = (await _dataLoaderHelper.LoadPositionsAsync()).ToList();
			Statuses = (await _dataLoaderHelper.LoadStatusesAsync()).ToList();
            return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{

			if (Photo != null && Photo.Length > 0)
			{
				using (var memoryStream = new System.IO.MemoryStream())
				{
					await Photo.CopyToAsync(memoryStream);
					Employee.Photo = memoryStream.ToArray();
				}
			}
			
			await _updateEmployeeUse.ExecuteAsync(Employee);

			return RedirectToPage("/Employees");
		}

    }
}
