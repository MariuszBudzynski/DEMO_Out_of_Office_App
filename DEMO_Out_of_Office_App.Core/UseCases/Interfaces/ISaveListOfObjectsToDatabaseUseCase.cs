using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface ISaveListOfObjectsToDatabaseUseCase
    {
        Task ExecuteAsync<T>(IEnumerable<T> objectList) where T : class, IEntityId;
    }
}