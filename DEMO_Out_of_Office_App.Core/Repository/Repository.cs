namespace DEMOOutOfOfficeApp.Core.Repository
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<T>> GetData<T>() where T : class, IEntityId
        {
            try
            {
                var data = await _appDbContext.Set<T>().ToListAsync();

                return data;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(T).Name);
                throw;
            }
            
        }

		public async Task SaveData<T>(T data) where T : class, IEntityId
		{

            try
            {
                var existingData = await _appDbContext.Set<T>().FindAsync(data.ID);

                if (existingData == null)
                {
                    await _appDbContext.Set<T>().AddAsync(data);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while saving data of type {Type}", typeof(T).Name);
                throw;
            }
        }

        public async Task SaveOrUpdateProjectEmployee(ProjectEmployee projectEmployee)
        {
            try
            {
                var existingData = await _appDbContext.ProjectEmployee.FindAsync(projectEmployee.ID);

                if (existingData == null)
                {
                    await _appDbContext.ProjectEmployee.AddAsync(projectEmployee);
                }
                else
                {

                    existingData.EmployeeID = projectEmployee.EmployeeID;
                    existingData.EmployeeID = projectEmployee.EmployeeID;

                }

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while saving data of type {Type}", typeof(ProjectEmployee).Name);
                throw;
            }
        }

        public async Task SaveLeaveRequestData(LeaveRequest leaveRequest)
        {

            try
            {
                if (leaveRequest != null)
                {
                    await _appDbContext.LeaveRequests.AddAsync(leaveRequest);
                    await _appDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while saving data of type {Type}", typeof(LeaveRequest).Name);
                throw;
            }

        }

        public async Task<IEnumerable<ProjectEmployee>> GetEmployeeProjects()
        {
            try
            {
                var empProjects = await _appDbContext.ProjectEmployee
                .Include(e => e.Employee)
                .Include(p => p.Project)
                .ToListAsync();
                return empProjects;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while geting data of type {Type}", typeof(ProjectEmployee).Name);
                throw;
            }
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var users = await _appDbContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while geting data of type {Type}", typeof(User).Name);
                throw;
            }
        }

        public async Task<T> GetDataById<T>(int id) where T : class, IEntityId
        {
            try
            {
                var data = await _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.ID == id);

                return data;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while geting data of type {Type}", typeof(T).Name);
                throw;
            }
        }

        public async Task UpdateProjectData(Project project)
        {
            try
            {
                if (project != null)
                {
                    var data = await GetDataById<Project>(project.ID);

                    if (data != null)
                    {
                        data.ID = project.ID;
                        data.ProjectType = project.ProjectType;
                        data.StartDate = project.StartDate;
                        data.EndDate = project.EndDate;
                        data.ProjectManager = project.ProjectManager;
                        data.Comment = project.Comment;

                        _appDbContext.Update(data);
                        await _appDbContext.SaveChangesAsync();
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating data of type {Type}", typeof(Project).Name);
                throw;
            }
        }

        public async Task SaveEmployeeData(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var data = await GetDataById<Employee>(employee.ID);
                    if (data == null)
                    {
                        await _appDbContext.AddAsync(employee);
                        await _appDbContext.SaveChangesAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while saving data of type {Type}", typeof(Employee).Name);
                throw;
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var data = await GetDataById<Employee>(employee.ID);
                    if (data != null)
                    {
                        data.FullName = employee.FullName;
                        data.Subdivision = employee.Subdivision;
                        data.PositionID = employee.PositionID;
                        data.StatusID = employee.StatusID;
                        data.PeoplePartnerID = employee.PeoplePartnerID;
                        data.OutOfOfficeBalance = employee.OutOfOfficeBalance;
                        data.Photo = data.Photo;
                        await _appDbContext.SaveChangesAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating data of type {Type}", typeof(Employee).Name);
                throw;
            }
        }

        public async Task UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            try
            {
                if (leaveRequest != null)
                {
                    var data = await GetDataById<LeaveRequest>(leaveRequest.ID);
                    if (data != null)
                    {
                        data.AbsenceReasonID = leaveRequest.AbsenceReasonID;
                        data.StartDate = leaveRequest.StartDate;
                        data.EndDate = leaveRequest.EndDate;
                        data.Comment = leaveRequest.Comment;
                        data.StatusType = data.StatusType;
                        await _appDbContext.SaveChangesAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating data of type {Type}", typeof(LeaveRequest).Name);
                throw;
            }
        }

        public async Task UpdateApprovalRequest(ApprovalRequest approvalRequest)
        {
            try
            {
                if (approvalRequest != null)
                {
                    var data = await GetDataById<ApprovalRequest>(approvalRequest.ID);
                    if (data != null)
                    {
                        _appDbContext.Update(approvalRequest);
                        await _appDbContext.SaveChangesAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating data of type {Type}", typeof(ApprovalRequest).Name);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                var employees = await _appDbContext.Employees
             .Include(e => e.Subdivision)
             .Include(e => e.Position)
             .Include(e => e.Status)
             .ToListAsync();

                return employees;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(Employee).Name);
                throw;
            }
        }

        public async Task<IEnumerable<ApprovalRequest>> GetEmpAprovalRequestsAsync()
        {
            try
            {
                var approvalRequests = await _appDbContext.ApprovalRequests
              .Include(lrs => lrs.LeaveRequest)
              .Include(ars => ars.ApprovalRequestStatus)
              .ToListAsync();

                return approvalRequests;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(ApprovalRequest).Name);
                throw;
            }
        }

        public async Task<ApprovalRequest> GetAprovalRequestsByIdAsync(int id)
        {
            try
            {
                var approvalRequests = await _appDbContext.ApprovalRequests
             .Include(ars => ars.ApprovalRequestStatus)
             .Include(apr => apr.Aprover)
             .FirstOrDefaultAsync(aprv => aprv.ID == id);

                return approvalRequests;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(ApprovalRequest).Name);
                throw;
            }
        }


        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync()
        {
            try
            {
                var leaveRequests = await _appDbContext.LeaveRequests
             .Include(lr => lr.Employee)
             .Include(lr => lr.AbsenceReason)
             .Include(lr => lr.LeaveRequestsStatus)
             .ToListAsync();

                return leaveRequests;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(LeaveRequest).Name);
                throw;
            }
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            try
            {
                var projects = await _appDbContext.Projects
             .Include(p => p.ProjectType)
             .Include(p => p.ProjectStatus)
             .Include(p => p.ProjectManager)
             .ToListAsync();

                return projects;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting data of type {Type}", typeof(Project).Name);
                throw;
            }
        }

        public async Task SaveListOfObjectsToDatabase<T>(IEnumerable<T> objectList) where T : class , IEntityId 
        {
            try
            {
                await _appDbContext.Set<T>().AddRangeAsync(objectList);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while saving data of type {Type}", typeof(T).Name);
                throw;
            }
        }
    }
}
