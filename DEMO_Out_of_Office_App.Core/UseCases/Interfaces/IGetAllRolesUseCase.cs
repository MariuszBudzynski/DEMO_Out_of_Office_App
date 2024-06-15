using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllRolesUseCase
    {
        Task<IEnumerable<Role>> ExecuteAsync();
    }
}