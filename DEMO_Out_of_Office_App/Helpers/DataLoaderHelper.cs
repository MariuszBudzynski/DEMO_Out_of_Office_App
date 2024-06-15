using DEMOOutOfOfficeApp.Core.Entities;
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

		public DataLoaderHelper(IGetAllSubdivisionsUseCase getAllSubdivisionsUseCase,
								IGetAllPositionsUseCase getAllPositionsUseCase,
								IGetAllRolesUseCase getAllRolesUse,
								IGetAllStatusesUseCase getAllStatusesUseCase
								)
		{
			_getAllSubdivisionsUseCase = getAllSubdivisionsUseCase;
			_getAllPositionsUseCase = getAllPositionsUseCase;
			_getAllRolesUse = getAllRolesUse;
			_getAllStatusesUseCase = getAllStatusesUseCase;
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
	}
}
