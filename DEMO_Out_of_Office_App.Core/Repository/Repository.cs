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
           return await _appDbContext.Set<T>().ToListAsync();

        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _appDbContext.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<T> GetDataById<T>(int id) where T : class, IEntityId
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(e=> e.ID == id);

        }

        public async Task SaveEmployeeData(Employee employee)
        {
            var data = await GetDataById<Employee>(employee.ID);

            if (data == null)
            {
                await _appDbContext.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _appDbContext.Update(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _appDbContext.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.PeoplePartner)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApprovalRequest>> GetEmpAprovalRequestsAsync()
        {
            return await _appDbContext.ApprovalRequests
          .Include(ar => ar.Approver)
          .Include(ar => ar.LeaveRequest)
          .Include(ar => ar.ApprovalRequestStatus)
          .ToListAsync();
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsAsync()
        {
                return await _appDbContext.LeaveRequests
            .Include(lr => lr.Employee)
            .Include(lr => lr.AbsenceReason)
            .Include(lr => lr.LeaveRequestsStatus)
            .ToListAsync();
        }

    }
}
