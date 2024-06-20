using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IUpdateProjectDataUseCase
    {
        Task ExecuteAsync(Project project);
    }
}