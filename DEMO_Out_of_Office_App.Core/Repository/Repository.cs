using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Context;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.X86;

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

            return data;
        }

        public async Task SaveLeaveRequestData(LeaveRequest leaveRequest)
        {
            if (leaveRequest != null)
            {
                await _appDbContext.LeaveRequests.AddAsync(leaveRequest);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProjectEmployee>> GetEmployeeProjects()
        {
            var empProjects = await _appDbContext.ProjectEmployee
                .Include(e => e.Employee)
                .Include(p => p.Project)
                .ToListAsync();
                return empProjects;
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _appDbContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .ToListAsync();

            return users;
        }

        public async Task<T> GetDataById<T>(int id) where T : class, IEntityId
        {
                var data = await _appDbContext.Set<T>().FirstOrDefaultAsync(e => e.ID == id);
 
                    return data;
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
                    data.AbsenceReasonID = leaveRequest.AbsenceReasonID;
                    data.StartDate = leaveRequest.StartDate;
                    data.EndDate = leaveRequest.EndDate;
                    data.Comment = leaveRequest.Comment;
                    data.StatusType =  data.StatusType;
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

            return employees;
        }

        public async Task<IEnumerable<ApprovalRequest>> GetEmpAprovalRequestsAsync()
        {



            var approvalRequests = await _appDbContext.ApprovalRequests
                .Include(ars => ars.ApprovalRequestStatus)
                .ToListAsync();

            return approvalRequests;
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync()
        {
            var leaveRequests = await _appDbContext.LeaveRequests
                .Include(lr => lr.Employee)
                .Include(lr => lr.AbsenceReason)
                .Include(lr => lr.LeaveRequestsStatus)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var projects = await _appDbContext.Projects
                .Include(p => p.ProjectType)
                .Include(p => p.ProjectStatus)
                .Include(p => p.ProjectManager)
                .ToListAsync();

            return projects;
        }



        public async Task SaveListOfObjectsToDatabase<T>(IEnumerable<T> objectList) where T : class , IEntityId 
        {
            await _appDbContext.Set<T>().AddRangeAsync(objectList);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
