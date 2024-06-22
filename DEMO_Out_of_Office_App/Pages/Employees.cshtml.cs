namespace DEMOOutOfOfficeApp.Pages
{
    [Authorize(Policy = "HRPMAdminPolicy")]
    public class EmployeesModel : PageModel
    {
        private readonly IGetAllEmployeesUseCase _getAllEmployeesUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IUpdateEmployeeUseCase _updateEmployeeUseCase;
        private readonly IGetAllUsersUseCase _getAllUsersUseCase;
        private IEnumerable<User> usersHRManagerROle;

        [BindProperty(SupportsGet = true)]
        public List<EmployeeDTO> Employees { get; set; }

        public EmployeesModel(IGetAllEmployeesUseCase getAllEmployeesUseCase,
                              IGetDataByIdUseCase getDataByIdUseCase,
                              IUpdateEmployeeUseCase updateEmployeeUseCase,
                              IGetAllUsersUseCase getAllUsersUseCase)
        {
            _getAllEmployeesUseCase = getAllEmployeesUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _updateEmployeeUseCase = updateEmployeeUseCase;
            _getAllUsersUseCase = getAllUsersUseCase;
        }
        public async Task OnGetAsync()
        {
            try
            {
                Employees = await FetchEmployeesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching employees.");
                throw;
            }
        }

        public async Task<IActionResult> OnPostDeactivateAsync(int employeeID)
        {
            try
            {
                var employee = await _getDataByIdUseCase.ExecuteAsync<Employee>(employeeID);
                if (employee != null)
                {
                    employee.StatusID = (int)Status.Inactive;
                    await _updateEmployeeUseCase.ExecuteAsync(employee);
                }

                Employees = await FetchEmployeesAsync();
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while deactivating employee.");
                throw;
            }
        }

        public IActionResult OnPostAdd()
        {
           return RedirectToPage("/AddEmployee");
        }

        public IActionResult OnPostEdit(int employeeID)
        {
			return RedirectToPage("/EditEmployee", new { id = employeeID });
		}

        public IActionResult OnPostAddToProject(int employeeID)
        {
            return RedirectToPage("/EmployeeProject", new { id = employeeID });
        }

        private async Task<List<EmployeeDTO>> FetchEmployeesAsync()
        {
            try
            {
                var employees = await _getAllEmployeesUseCase.ExecuteAsync();

                usersHRManagerROle = (await _getAllUsersUseCase.ExecuteAsync()).ToList().Where(e => e.RoleID == (int)UserRole.HRManager);


                foreach (var employee in employees)
                {
                    var peoplePartner = await GetPeoplePartner(employee.PeoplePartnerID);

                    var employeeDTO = new EmployeeDTO(
                        employee.ID,
                        employee.FullName,
                        employee.Subdivision.Name,
                        employee.Position.UserRoleDescription,
                        employee.Status.StatusDescription,
                        peoplePartner,
                        employee.OutOfOfficeBalance,
                        employee.Photo,
                        employee.Position.ID
                    );

                    Employees.Add(employeeDTO);
                }

                return Employees;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching employees.");
                throw;
            }

        }

        private async Task<string> GetPeoplePartner(int peoplePartnerId)
        {
            try
            {
                var data = await _getDataByIdUseCase.ExecuteAsync<User>(peoplePartnerId);
                return data.FullName;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while fetching people partner.");
                throw;
            }
        }

		private async Task<Employee> ConvertToEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                var subdivision = await _getDataByIdUseCase.ExecuteAsync<Subdivision>(employeeDTO.ID);
                var status = await _getDataByIdUseCase.ExecuteAsync<EmployeeStatus>(employeeDTO.ID);
                var role = await _getDataByIdUseCase.ExecuteAsync<Role>(employeeDTO.ID);

                return new Employee
                {
                    ID = employeeDTO.ID,
                    FullName = employeeDTO.FullName,
                    SubdivisionID = subdivision.ID,
                    PositionID = employeeDTO.rolePositionId,
                    StatusID = status.ID,
                    PeoplePartnerID = role.ID,
                    OutOfOfficeBalance = employeeDTO.OutOfOfficeBalance
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while converting to employee.");
                throw;
            }
        }

    }
}
