using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllPositionsUseCase
    {
        Task<IEnumerable<Position>> ExecuteAsync();
    }
}