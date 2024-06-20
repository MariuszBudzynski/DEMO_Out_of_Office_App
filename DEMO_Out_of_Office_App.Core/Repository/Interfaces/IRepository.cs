using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.Repository.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetData<T>() where T : class, IEntityId;
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<T> GetDataById<T>(int id) where T : class, IEntityId;
        Task UpdateEmployee(Employee employee);
        Task SaveEmployeeData(Employee employee);
        Task<IEnumerable<ApprovalRequest>> GetEmpAprovalRequestsAsync();
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task UpdateLeaveRequest(LeaveRequest leaveRequest);
        Task UpdateApprovalRequest(ApprovalRequest approvalRequest);
        Task SaveLeaveRequestData(LeaveRequest leaveRequest);
        Task<IEnumerable<ProjectEmployee>> GetEmployeeProjects();
        Task SaveListOfObjectsToDatabase<T>(IEnumerable<T> objectList) where T : class, IEntityId;
        //Task SaveListOfApprovalRequestExtendedToDatabase(IEnumerable<ApprovalRequestExtended> approvalRequestExtendedList);
    }
}