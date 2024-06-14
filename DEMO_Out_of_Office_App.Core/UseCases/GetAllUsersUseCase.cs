using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;

namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IRepository _repository;

        public GetAllUsersUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId, IEmployeeID, IUsername, IPasswordHash
        {
            return await _repository.GetData<T>();
        }
    }
}
