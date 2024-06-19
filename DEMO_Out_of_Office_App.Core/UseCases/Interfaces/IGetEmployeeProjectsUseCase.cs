using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetEmployeeProjectsUseCase
    {
        Task<IEnumerable<ProjectEmployee>> ExecuteAsync();
    }
}