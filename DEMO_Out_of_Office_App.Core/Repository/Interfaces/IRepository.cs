using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.Repository.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetData<T>() where T : class, IEntityId;
        Task<IEnumerable<Employee>> GetEmployeesAsync();
    }
}