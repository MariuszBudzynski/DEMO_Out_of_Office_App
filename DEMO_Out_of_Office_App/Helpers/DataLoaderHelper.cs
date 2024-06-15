using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.UseCases;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using DEMOOutOfOfficeApp.Helpers.Interfaces;

namespace DEMOOutOfOfficeApp.Helpers
{
    public class DataLoaderHelper : IDataLoaderHelper
	{
		private readonly IGetAllSubdivisionsUseCase _getAllSubdivisionsUseCase;
		private readonly IGetAllPositionsUseCase _getAllPositionsUseCase;
		private readonly IGetAllRolesUseCase _getAllRolesUse;
		private readonly IGetAllStatusesUseCase _getAllStatusesUseCase;
		private readonly IGetDataByIdUseCase _getDataByIdUseCase;

		public DataLoaderHelper(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
								IGetAllPositionsUseCase getAllPositionsUseCase,
								IGetAllRolesUseCase getAllRolesUse,
								IGetAllStatusesUseCase getAllStatusesUseCase,
								IGetDataByIdUseCase getDataByIdUseCase
								)
		{
			_getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
			_getAllPositionsUseCase = getAllPositionsUseCase;
			_getAllRolesUse = getAllRolesUse;
			_getAllStatusesUseCase = getAllStatusesUseCase;
			_getDataByIdUseCase = getDataByIdUseCase;
		}

		public async Task<List<Subdivision>> LoadSubdivisionsAsync()
		{
			return (await _getAllSubdivisionsUseCase.ExecuteAsync()).ToList();
		}

		public async Task<List<Role>> LoadRolesAsync()
		{
			return (await _getAllRolesUse.ExecuteAsync()).ToList();
		}

		public async Task<List<Position>> LoadPositionsAsync()
		{
			return (await _getAllPositionsUseCase.ExecuteAsync()).ToList();
		}

		public async Task<List<EmployeeStatus>> LoadStatusesAsync()
		{
			return (await _getAllStatusesUseCase.ExecuteAsync()).ToList();
		}

		public async Task<Employee> LoadEmpoloyeeAsync(int id)
		{
			return await _getDataByIdUseCase.ExecuteAsync<Employee>( id );
		}
	}
}
