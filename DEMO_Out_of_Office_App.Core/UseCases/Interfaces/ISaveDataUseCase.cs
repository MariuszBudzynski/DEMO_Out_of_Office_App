using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface ISaveDataUseCase
    {
        Task ExecuteAsync<T>(T data) where T : class, IEntityId;
    }
}