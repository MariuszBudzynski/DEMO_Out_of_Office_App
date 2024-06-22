namespace DEMOOutOfOfficeApp.Helpers
{
    public class DataLoaderHelper : IDataLoaderHelper
    {
        private readonly IGetAllSubdivisionsUseCase _getAllSubdivisionsUseCase;
        private readonly IGetAllRolesUseCase _getAllRolesUse;
        private readonly IGetAllStatusesUseCase _getAllStatusesUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IGetProjectsUseCase _getProjectsUseCase;
        private readonly IGetLeaveRequestsUseCase _getLeaveRequestsUseCase;
        private readonly IGetDataUseCase _getDataUseCase;
        private readonly IGetEmployeeProjectsUseCase _getEmployeeProjectsUseCase;
        private readonly IGetAprovalRequestsByIdUseCase _getAprovalRequestsByIdUseCase;

        public DataLoaderHelper(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
                                IGetAllRolesUseCase getAllRolesUse,
                                IGetAllStatusesUseCase getAllStatusesUseCase,
                                IGetDataByIdUseCase getDataByIdUseCase,
                                IGetProjectsUseCase getProjectsUseCase,
                                IGetLeaveRequestsUseCase getLeaveRequestsUseCase,
                                IGetDataUseCase getDataUseCase,
                                IGetEmployeeProjectsUseCase getEmployeeProjectsUseCase,
                                IGetAprovalRequestsByIdUseCase getAprovalRequestsByIdUseCase
                                )
        {
            _getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
            _getAllRolesUse = getAllRolesUse;
            _getAllStatusesUseCase = getAllStatusesUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _getProjectsUseCase = getProjectsUseCase;
            _getLeaveRequestsUseCase = getLeaveRequestsUseCase;
            _getDataUseCase = getDataUseCase;
            _getEmployeeProjectsUseCase = getEmployeeProjectsUseCase;
            _getAprovalRequestsByIdUseCase = getAprovalRequestsByIdUseCase;
        }

        public async Task<Project> LoadProjectByIDAsync(int projectID)
        {
            try
            {
                return (await _getDataByIdUseCase.ExecuteAsync<Project>(projectID));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAbsenceReasonAsync");
                throw;
            }
        }

        public async Task<IEnumerable< Project>> LoadAsllProjectsAsync()
        {
            
            try
            {
                return await _getDataUseCase.ExecuteAsync<Project>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAsllProjectsAsync");
                throw;
            }
        }

        public async Task<ApprovalRequest> LoadAprovalRequestAsync(int id)
        {

            try
            {
                return (await _getAprovalRequestsByIdUseCase.ExecuteAsync(id));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAprovalRequestAsync");
                throw;
            }
        }

        public async Task<IEnumerable<Subdivision>> LoadSubdivisionsAsync()
        {
            try
            {
                return (await _getAllSubdivisionsUseCase.ExecuteAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadSubdivisionsAsync");
                throw;
            }
        }

        public async Task<IEnumerable<ProjectType>> LoadProjectTypesAsync()
        {
            try
            {
                return (await _getDataUseCase.ExecuteAsync<ProjectType>()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadProjectTypesAsync");
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> LoadAllEmployeesAsync()
        {
            try
            {
                return (await _getDataUseCase.ExecuteAsync<Employee>()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAllEmployeesAsync");
                throw;
            }
        }

        public async Task<IEnumerable<User>> LoadAllUsersAsync()
        {
            try
            {
                return (await _getDataUseCase.ExecuteAsync<User>()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAllUsersAsync");
                throw;
            }
        }

        public async Task<IEnumerable<LeaveRequest>> LoadAllLeaveRequestAsync()
        {
            try
            {
                return (await _getDataUseCase.ExecuteAsync<LeaveRequest>()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAllLeaveRequestAsync");
                throw;
            }
        }

        public async Task<IEnumerable<Role>> LoadRolesAsync()
        {
            try
            {
                return (await _getAllRolesUse.ExecuteAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadRolesAsync");
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeStatus>> LoadStatusesAsync()
        {
            try
            {
                return (await _getAllStatusesUseCase.ExecuteAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadStatusesAsync");
                throw;
            }
        }

        public async Task<Employee> LoadEmpoloyeeAsync(int id)
        {
            try
            {
                return await _getDataByIdUseCase.ExecuteAsync<Employee>(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadEmpoloyeeAsync for id {EmployeeId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<ProjectEmployee>> LoadEmployeeProjects()
        {
            try
            {
                return await _getEmployeeProjectsUseCase.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadEmployeeProjects");
                throw;
            }
        }


        public async Task<string> LoadLeaveRequestStatusAsync(int id)
        {
            try
            {
                var leaveRequest = await _getDataByIdUseCase.ExecuteAsync<LeaveRequest>(id);
                return leaveRequest?.StatusType.ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadLeaveRequestStatusAsync for LeaveRequest ID {LeaveRequestId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Project>> LoadEmpoloyeeProjects(int employeeId)
        {
            try
            {
                var projects = await _getProjectsUseCase.ExecuteAsync();

                if (employeeId != 0)
                {
                    projects = projects.Where(p => p.ProjectManagerID == employeeId).ToList();
                }

                return projects;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadEmpoloyeeProjectsAsync for Employee ID {EmployeeId}", employeeId);
                throw;
            }
        }

        public async Task<IEnumerable<AbsenceReason>> LoadAbsenceReasonAsync()
        {
            try
            {
                return await _getDataUseCase.ExecuteAsync<AbsenceReason>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadAbsenceReasonAsync");
                throw;
            }
        }

        public async Task<IEnumerable<ProjectDTO>> LoadProjectsDTOAsync()
        {
            try
            {
                List<ProjectDTO> projectDTOs = new List<ProjectDTO>();

                var employeeprojects = await _getEmployeeProjectsUseCase.ExecuteAsync();
                var projects = await _getProjectsUseCase.ExecuteAsync();

                if (projects != null)
                {
                    foreach (var project in projects)
                    {
                        string employeeName = "No Employee Assigned";

                        var projectEmployee = employeeprojects.FirstOrDefault(ep => ep.ProjectID == project.ID);
                        if (projectEmployee != null)
                        {
                            employeeName = projectEmployee.Employee.FullName ?? "No Employee Assigned";
                        }

                        var projectDTO = new ProjectDTO(
                            project.ID,
                            project.ProjectType.Name,
                            project.StartDate,
                            project.EndDate,
                            employeeName,
                            project.ProjectManagerID,
                            project.ProjectManager.FullName ?? "No Manager Assigned",
                            project.Comment,
                            project.ProjectStatus.StatusType.ToString()
                        );

                        projectDTOs.Add(projectDTO);
                    }
                }

                return projectDTOs;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadProjectsDTOAsync");
                throw;
            }
        }

        public async Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync(int employeeId)
        {
            try
            {
                var leaveRequests = await _getLeaveRequestsUseCase.ExecuteAsync();

                if (employeeId != 0)
                {
                    leaveRequests = leaveRequests.Where(p => p.EmployeeID == employeeId).ToList();
                }

                var leaveRequestsDTO = leaveRequests.Select(e => new LeaveRequestDTO(
                    e.ID,
                    e.Employee.PeoplePartnerID,
                    e.Employee.FullName,
                    e.AbsenceReason.Name,
                    e.StartDate,
                    e.EndDate,
                    e.Comment,
                    e.LeaveRequestsStatus.Description
                )).ToList();

                return leaveRequestsDTO;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadLeaveRequestsDTOAsync for Employee ID {EmployeeId}", employeeId);
                throw;
            }
        }

        public async Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync()
        {
            try
            {
                var leaveRequests = await _getLeaveRequestsUseCase.ExecuteAsync();

                var leaveRequestsDTO = leaveRequests.Select(e => new LeaveRequestDTO(
                    e.ID,
                    e.Employee.PeoplePartnerID,
                    e.Employee.FullName,
                    e.AbsenceReason.Name,
                    e.StartDate,
                    e.EndDate,
                    e.Comment,
                    e.LeaveRequestsStatus.Description
                )).ToList();

                return leaveRequestsDTO;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in LoadLeaveRequestsDTOAsync");
                throw;
            }
        }

        public async Task<IEnumerable<PeoplePartnerDTO>> GetListOfPeoplePartner()
        {
            try
            {
                var usersHRManagerRole = (await LoadAllUsersAsync()).Where(e => e.RoleID == (int)UserRole.HRManager).ToList();

                var peoplePartnersDTO = usersHRManagerRole.Select(e => new PeoplePartnerDTO(
                    e.ID,
                    e.FullName
                )).ToList();

                return peoplePartnersDTO;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in GetListOfPeoplePartner");
                throw;
            }
        }

    }
}
