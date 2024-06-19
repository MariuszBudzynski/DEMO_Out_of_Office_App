using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.DTOS;

namespace DEMOOutOfOfficeApp.Helpers.Interfaces
{
    public interface IDataLoaderHelper
    {
        Task<IEnumerable<AbsenceReason>> LoadAbsenceReasonAsync();
        Task<IEnumerable<Employee>> LoadAllEmployeesAsync();
        Task<IEnumerable<LeaveRequest>> LoadAllLeaveRequestAsync();
        Task<Employee> LoadEmpoloyeeAsync(int id);
        Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync();
        Task<IEnumerable<LeaveRequestDTO>> LoadLeaveRequestsDTOAsync(int employeeId);
        Task<IEnumerable<ProjectDTO>> LoadProjectsDTOAsync();
        Task<IEnumerable<Role>> LoadRolesAsync();
        Task<IEnumerable<EmployeeStatus>> LoadStatusesAsync();
        Task<IEnumerable<Subdivision>> LoadSubdivisionsAsync();
        Task<IEnumerable<Project>> LoadEmpoloyeeProjects(int employeeId);
        Task<IEnumerable<User>> LoadAllUsersAsync();
        Task<IEnumerable<PeoplePartnerDTO>> GetListOfPeoplePartner();
        Task<IEnumerable<ProjectEmployee>> LoadEmployeeProjects();
    }
}