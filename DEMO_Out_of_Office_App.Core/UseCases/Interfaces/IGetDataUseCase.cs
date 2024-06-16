using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetDataUseCase
    {
        Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId;
    }
}