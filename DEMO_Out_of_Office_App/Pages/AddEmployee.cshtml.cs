namespace DEMOOutOfOfficeApp.Pages
{
    public class AddEmployeeModel : PageModel, IEmployeeFormModel
    {
        private readonly IDataLoaderHelper _dataLoaderHelper;
        private readonly ISaveSingleEmployeeUseCase _saveSingleEmployeeUseCase;
        private IEnumerable<User> usersHRManagerRole;

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public int ID { get; set; }
        public List<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
        public List<EmployeeStatus> Statuses { get; set; } = new List<EmployeeStatus>();
        public List<PeoplePartnerDTO> PeoplePartner { get; set; } = new List<PeoplePartnerDTO>();
        public List<Role> Roles { get; set; } = new List<Role>();

        public AddEmployeeModel(IDataLoaderHelper dataLoaderHelper, ISaveSingleEmployeeUseCase saveSingleEmployeeUseCase)
        {
            _dataLoaderHelper = dataLoaderHelper;
            _saveSingleEmployeeUseCase = saveSingleEmployeeUseCase;
        }

        public async Task OnGet()
        {
            try
            {
                Subdivisions = (await _dataLoaderHelper.LoadSubdivisionsAsync()).ToList();
                Statuses = (await _dataLoaderHelper.LoadStatusesAsync()).ToList();
                PeoplePartner = (await GetListOfPeoplePartner()).ToList();
                Roles = (await _dataLoaderHelper.LoadRolesAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnGet method.");
                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (Photo != null && Photo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await Photo.CopyToAsync(memoryStream);
                        Employee.Photo = memoryStream.ToArray();
                    }
                }

                await _saveSingleEmployeeUseCase.ExecuteAsync(Employee);

                return RedirectToPage("/Employees");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in OnPostAsync method.");
                throw;
            }
        }

        private async Task<List<PeoplePartnerDTO>> GetListOfPeoplePartner()
        {
            try
            {
                usersHRManagerRole = (await _dataLoaderHelper.LoadAllUsersAsync()).Where(e => e.RoleID == (int)UserRole.HRManager).ToList();

                return usersHRManagerRole.Select(e => new PeoplePartnerDTO(
                    e.ID,
                    e.FullName
                )).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred in GetListOfPeoplePartner method.");
                throw;
            }
        }
    }
}
