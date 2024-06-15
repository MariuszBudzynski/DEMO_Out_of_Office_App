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
    public class GetDataByIdUseCase : IGetDataByIdUseCase
    {
        private readonly IRepository _repository;

        public GetDataByIdUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> ExecuteAsync<T>(int id) where T : class, IEntityId
        {
            return await _repository.GetDataById<T>(id);
        }
    }
}
