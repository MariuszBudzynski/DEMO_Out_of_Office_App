using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllEmployeesUseCase
    {
        Task<IEnumerable<Employee>> ExecuteAsync();
    }
}