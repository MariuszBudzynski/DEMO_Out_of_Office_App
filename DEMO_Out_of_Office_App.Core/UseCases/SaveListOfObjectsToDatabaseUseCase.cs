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
    public class SaveListOfObjectsToDatabaseUseCase : ISaveListOfObjectsToDatabaseUseCase
    {
        private readonly IRepository _repository;

        public SaveListOfObjectsToDatabaseUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync<T>(IEnumerable<T> objectList) where T : class, IEntityId
        {
            await _repository.SaveListOfObjectsToDatabase(objectList);
        }
    }
}
