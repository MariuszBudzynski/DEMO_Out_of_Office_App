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
        private readonly IGetAllPositionsUseCase _getAllPositionsUseCase;
        private readonly IGetAllRolesUseCase _getAllRolesUse;
        private readonly IGetAllStatusesUseCase _getAllStatusesUseCase;
        private readonly IGetDataByIdUseCase _getDataByIdUseCase;
        private readonly IGetProjectsUseCase _getProjectsUseCase;
        private readonly IGetLeaveRequestsUseCase _getLeaveRequestsUseCase;
        private readonly IGetDataUseCase _getDataUseCase;

        public DataLoaderHelper(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
                                IGetAllPositionsUseCase getAllPositionsUseCase,
                                IGetAllRolesUseCase getAllRolesUse,
                                IGetAllStatusesUseCase getAllStatusesUseCase,
                                IGetDataByIdUseCase getDataByIdUseCase,
                                IGetProjectsUseCase getProjectsUseCase,
                                IGetLeaveRequestsUseCase getLeaveRequestsUseCase,
                                IGetDataUseCase getDataUseCase
                                )
        {
            _getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
            _getAllPositionsUseCase = getAllPositionsUseCase;
            _getAllRolesUse = getAllRolesUse;
            _getAllStatusesUseCase = getAllStatusesUseCase;
            _getDataByIdUseCase = getDataByIdUseCase;
            _getProjectsUseCase = getProjectsUseCase;
            _getLeaveRequestsUseCase = getLeaveRequestsUseCase;
            _getDataUseCase = getDataUseCase;
        }

        public async Task<IEnumerable<Subdivision>> LoadSubdivisionsAsync()
        {
            return (await _getAllSubdivisionsUseCase.ExecuteAsync()).ToList();
        }

        public async Task<IEnumerable<Employee>> LoadAllEmployeesAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<Employee>()).ToList();
        }

        public async Task<IEnumerable<LeaveRequest>> LoadAllLeaveRequestAsync()
        {
            return (await _getDataUseCase.ExecuteAsync<LeaveRequest>()).ToList();
        }

        public async Task<IEnumerable<Role>> LoadRolesAsync()
        {
            return (await _getAllRolesUse.ExecuteAsync()).ToList();
        }

        public async Task<IEnumerable<Position>> LoadPositionsAsync()
        {
            return (await _getAllPositionsUseCase.ExecuteAsync()).ToList();
        }

        public async Task<IEnumerable<EmployeeStatus>> LoadStatusesAsync()
        {
            return (await _getAllStatusesUseCase.ExecuteAsync()).ToList();
        }

        public async Task<Employee> LoadEmpoloyeeAsync(int id)
        {
            return await _getDataByIdUseCase.ExecuteAsync<Employee>(id);
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

        public async Task<IEnumerable<ProjectDTO>> LoadProjectsDTOAsync(int employeeId)
        {
            var projects = await _getProjectsUseCase.ExecuteAsync();

            if (employeeId != 0)
            {
                projects = projects.Where(p => p.ProjectManagerID == employeeId).ToList();
            }

            var projectsDTO = projects.Select(e => new ProjectDTO(
                e.ID,
                e.ProjectType.Name,
                e.StartDate,
                e.EndDate,
                e.ProjectManager.FullName,
                e.Comment,
                e.ProjectStatus.StatusType.ToString()
            )).ToList();

            return projectsDTO;
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
                e.Employee.FullName,
                e.AbsenceReason.Name,
                e.StartDate,
                e.EndDate,
                e.Comment,
                e.LeaveRequestsStatus.Description
            )).ToList();

            return projectsDTO;
        }

    }
}
