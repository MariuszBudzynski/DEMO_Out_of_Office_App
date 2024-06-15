using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetDataByIdUseCase
    {
        Task<T> ExecuteAsync<T>(int id) where T : class, IEntityId;
    }
}