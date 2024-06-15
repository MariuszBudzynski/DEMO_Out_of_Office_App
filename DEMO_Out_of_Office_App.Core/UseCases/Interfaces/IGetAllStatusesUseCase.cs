using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllStatusesUseCase
    {
        Task<IEnumerable<EmployeeStatus>> ExecuteAsync();
    }
}