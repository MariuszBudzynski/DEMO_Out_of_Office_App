namespace DEMOOutOfOfficeApp.Pages
{
    public class EditEmployeeModel : PageModel , IEmployeeFormModel
	{
		private readonly IDataLoaderHelper _dataLoaderHelper;
		private readonly ISaveSingleEmployeeUseCase _saveSingleEmployeeUseCase;
		private readonly IUpdateEmployeeUseCase _updateEmployeeUse;
        private IEnumerable<User> usersHRManagerROle;

        [BindProperty]
		public Employee Employee { get; set; }

		[BindProperty]
		public IFormFile Photo { get; set; }
        public int ID { get; set; }
        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
		public List<EmployeeStatus> Statuses { get; set; } = new List<EmployeeStatus>();
		public List<Role> Roles { get; set; } = new List<Role>();
		public List<PeoplePartnerDTO> PeoplePartner { get; set; } = new();

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
            try
            {
                Employee = await _dataLoaderHelper.LoadEmpoloyeeAsync(id);
                Subdivisions = (await _dataLoaderHelper.LoadSubdivisionsAsync()).ToList();
                Statuses = (await _dataLoaderHelper.LoadStatusesAsync()).ToList();
                PeoplePartner = (await _dataLoaderHelper.GetListOfPeoplePartner()).ToList();
                Roles = (await _dataLoaderHelper.LoadRolesAsync()).ToList();
                return Page();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling GET request in EditEmployeeModel.");
                throw;
            }
        }

		public async Task<IActionResult> OnPostAsync()
		{
			try
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
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while handling POST request in EditEmployeeModel.");
                throw;
            }

        }
        private async Task<List<PeoplePartnerDTO>> GetListOfPeoplePartner()
        {   
            try
            {
                usersHRManagerROle = (await _dataLoaderHelper.LoadAllUsersAsync()).ToList().Where(e => e.RoleID == (int)UserRole.HRManager);

                return usersHRManagerROle.Select(e => new PeoplePartnerDTO(
                    e.ID,
                    e.FullName
                    )).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while retrieving list of People Partners in EditEmployeeModel.");
                throw;
            }

        }

    }
}
