using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllDataUseCase
    {
        Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId, IEmployeeID, IUsername, IPasswordHash;
    }
}