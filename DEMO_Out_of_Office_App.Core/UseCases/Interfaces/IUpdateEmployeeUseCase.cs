using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IUpdateEmployeeUseCase
    {
        Task ExecuteAsync(Employee employee);
    }
}