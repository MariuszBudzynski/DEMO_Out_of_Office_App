using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface ISaveOrUpdateProjectEmployeeUseCase
    {
        Task ExecuteAsync(ProjectEmployee projectEmployee);
    }
}