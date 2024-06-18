using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Context;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            var data = await _appDbContext.Set<T>().ToListAsync();
            if (data == null || !data.Any())
            {
                return Enumerable.Empty<T>();
            }
            return data;
        }

        public async Task SaveData<T>(T data) where T : class, IEntityId
        {
            if (data != null)
            {
                await _appDbContext.Set<T>().AddAsync(data);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _appDbContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .ToListAsync();

            if (users == null || !users.Any())
            {
                return Enumerable.Empty<User>();
            }
            return users;
        }

        public async Task<T> GetDataById<T>(int id) where T : class, IEntityId
        {
            if (id > 0)
            {
                var data = await _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }

        public async Task SaveEmployeeData(Employee employee)
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

        public async Task UpdateEmployee(Employee employee)
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

        public async Task UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            if (leaveRequest != null)
            {
                var data = await GetDataById<LeaveRequest>(leaveRequest.ID);
                if (data != null)
                {
                    _appDbContext.Update(leaveRequest);
                    await _appDbContext.SaveChangesAsync();
                }
            }
        }

        public async Task UpdateApprovalRequest(ApprovalRequest approvalRequest)
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

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await _appDbContext.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .ToListAsync();

            if (employees == null || !employees.Any())
            {
                return Enumerable.Empty<Employee>();
            }
            return employees;
        }

        public async Task<IEnumerable<ApprovalRequest>> GetEmpAprovalRequestsAsync()
        {
            var approvalRequests = await _appDbContext.ApprovalRequests
                .Include(ar => ar.Approver)
                .Include(ar => ar.LeaveRequest)
                .Include(ar => ar.ApprovalRequestStatus)
                .ToListAsync();

            if (approvalRequests == null || !approvalRequests.Any())
            {
                return Enumerable.Empty<ApprovalRequest>();
            }
            return approvalRequests;
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync()
        {
            var leaveRequests = await _appDbContext.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.AbsenceReason)
                .Include(lr => lr.LeaveRequestsStatus)
                .ToListAsync();

            if (leaveRequests == null || !leaveRequests.Any())
            {
                return Enumerable.Empty<LeaveRequest>();
            }
            return leaveRequests;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects = await _appDbContext.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectManager)
                .ToListAsync();

            if (projects == null || !projects.Any())
            {
                return Enumerable.Empty<Project>();
            }
            return projects;
        }
    }
}
