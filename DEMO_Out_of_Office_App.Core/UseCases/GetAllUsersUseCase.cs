using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
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

        public async Task<IEnumerable<User>> ExecuteAsync() 
        {
            return await _repository.GetUsersAsync();
        }
    }
}
