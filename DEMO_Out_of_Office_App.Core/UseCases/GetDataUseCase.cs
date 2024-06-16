using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetDataUseCase : IGetDataUseCase
    {
        private readonly IRepository _repository;

        public GetDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId
        {
            return await _repository.GetData<T>();
        }
    }
}
