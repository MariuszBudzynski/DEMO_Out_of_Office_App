using DEMOOutOfOfficeApp.Common.Interfaces;
using DEMOOutOfOfficeApp.Core.Entities;
using DEMOOutOfOfficeApp.Core.Repository.Interfaces;
using DEMOOutOfOfficeApp.Core.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class SaveDataUseCase : ISaveDataUseCase
    {
        private readonly IRepository _repository;

        public SaveDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync<T>(T data) where T : class, IEntityId
        {
            try
            {
                await _repository.SaveData<T>(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing SaveDataUseCase");
                throw;
            }
        }
    }
}
