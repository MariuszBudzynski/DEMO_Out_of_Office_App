using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetProjectsUseCase
    {
        Task<IEnumerable<Project>> ExecuteAsync();
    }
}