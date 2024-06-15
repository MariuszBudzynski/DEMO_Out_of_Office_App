using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAllSubdivisionsUseCase
    {
        Task<IEnumerable<Subdivision>> ExecuteAsync();
    }
}