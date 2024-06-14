using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllUsersUseCase
    {
        Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId, IEmployeeID, IUsername, IPasswordHash;
    }
}