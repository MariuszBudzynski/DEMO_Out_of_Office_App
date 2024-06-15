using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;

namespace DEMOOutOfOfficeApp.Helpers.Interfaces
{
    public interface IDataLoaderHelper
    {
        Task<List<Position>> LoadPositionsAsync();
        Task<List<Role>> LoadRolesAsync();
        Task<List<EmployeeStatus>> LoadStatusesAsync();
        Task<List<Subdivision>> LoadSubdivisionsAsync();
        Task<Employee> LoadEmpoloyeeAsync(int id);
	}
}