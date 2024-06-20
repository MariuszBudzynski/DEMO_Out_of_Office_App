using DEMOOutOfOfficeApp.Common.Enums;
using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.DTOS;
using DEMOOutOfOfficeApp.Helpers.Interfaces;
using System.Linq;

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

        public DataLoaderHelper(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
                                IGetAllRolesUseCase getAllRolesUse,
                                IGetAllStatusesUseCase getAllStatusesUseCase,
                                IGetDataByIdUseCase getDataByIdUseCase,
                                IGetProjectsUseCase getProjectsUseCase,
                                IGetLeaveRequestsUseCase getLeaveRequestsUseCase,
                                IGetDataUseCase getDataUseCase,
                                IGetEmployeeProjectsUseCase getEmployeeProjectsUseCase
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
        }

        public async Task<IEnumerable<Subdivision>> LoadSubdivisionsAsync()
        {
            return (await _getAllSubdivisionsUseCase.ExecuteAsync()).ToList();
        }

        public async Task<IEnumerable<ProjectType>> LoadProjectTypesAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<ProjectType>()).ToList();
        }

        public async Task<IEnumerable<Employee>> LoadAllEmployeesAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<Employee>()).ToList();
        }

        public async Task<IEnumerable<User>> LoadAllUsersAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<User>()).ToList();
        }

        public async Task<IEnumerable<LeaveRequest>> LoadAllLeaveRequestAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<LeaveRequest>()).ToList();
        }

        public async Task<IEnumerable<Role>> LoadRolesAsync()
        {
            return (await _getAllRolesUse.ExecuteAsync()).ToList();
        }

        public async Task<IEnumerable<EmployeeStatus>> LoadStatusesAsync()
        {
            return (await _getAllStatusesUseCase.ExecuteAsync()).ToList();
        }

        public async Task<Employee> LoadEmpoloyeeAsync(int id)
        {
            return await _getDataByIdUseCase.ExecuteAsync<Employee>(id);
        }

        public async Task<IEnumerable<ProjectEmployee>> LoadEmployeeProjects()
        {

            return await _getEmployeeProjectsUseCase.ExecuteAsync();
        }

        public async Task<string> LoadLeaveRequestStatusAsync(int id)
        {
            var leaveRequest = await _getDataByIdUseCase.ExecuteAsync<LeaveRequest>(id);
            return leaveRequest?.StatusType.ToString();
        }

        public async Task<IEnumerable<Project>> LoadEmpoloyeeProjects(int employeeId)
        {
            var projects = await _getProjectsUseCase.ExecuteAsync();

            if (employeeId != 0)
            {
                return projects = projects.Where(p => p.ProjectManagerID == employeeId).ToList();
            }

            return projects;
        }

        public async Task<IEnumerable<AbsenceReason>> LoadAbsenceReasonAsync()
        {
            return await _getDataUseCase.ExecuteAsync<AbsenceReason>();
        }

        public async Task<IEnumerable<ProjectDTO>> LoadProjectsDTOAsync()
        {
            List<ProjectDTO> projectDTOs = new List<ProjectDTO>();

            var employeeprojects = await _getEmployeeProjectsUseCase.ExecuteAsync();

            var projects = await _getProjectsUseCase.ExecuteAsync();

            if (employeeprojects != null)
            {
                foreach (var projectEmpl in employeeprojects)
                {
                    var projectDTO = new ProjectDTO(

                        projectEmpl.ProjectID,
                        projectEmpl.Project.ProjectType.Name,
                        projectEmpl.Project.StartDate,
                        projectEmpl.Project.EndDate,
                        projectEmpl.Employee.FullName ?? String.Empty,
                        projectEmpl.EmployeeID,
                        projectEmpl.Project.ProjectManager.FullName ?? String.Empty,
                        projectEmpl.Project.Comment,
                        projectEmpl.Project.ProjectStatus.StatusType.ToString()

                        );
                    projectDTOs.Add(projectDTO);
                }
            }

            return projectDTOs;
        }

        public async Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync(int employeeId)
        {
            var projects = await _getLeaveRequestsUseCase.ExecuteAsync();

            if (employeeId != 0)
            {
                projects = projects.Where(p => p.EmployeeID == employeeId).ToList();
            }

            var projectsDTO = projects.Select(e => new LeaveRequestDTO(
                e.ID,
                e.Employee.PeoplePartnerID,
                e.Employee.FullName,
                e.AbsenceReason.Name,
                e.StartDate,
                e.EndDate,
                e.Comment,
                e.LeaveRequestsStatus.Description
            )).ToList();

            return projectsDTO;
        }

        public async Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync()
        {
            var projects = await _getLeaveRequestsUseCase.ExecuteAsync();


            var projectsDTO = projects.Select(e => new LeaveRequestDTO(
                e.ID,
                e.Employee.PeoplePartnerID,
                e.Employee.FullName,
                e.AbsenceReason.Name,
                e.StartDate,
                e.EndDate,
                e.Comment,
                e.LeaveRequestsStatus.Description
            )).ToList();

            return projectsDTO;
        }

        public async Task<IEnumerable<PeoplePartnerDTO>> GetListOfPeoplePartner()
        {
            var usersHRManagerROle = (await LoadAllUsersAsync()).ToList().Where(e => e.RoleID == (int)UserRole.HRManager);

            return usersHRManagerROle.Select(e => new PeoplePartnerDTO(
                e.ID,
                e.FullName
                ));

        }
    }
}
