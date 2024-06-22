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
    public class SaveOrUpdateProjectEmployeeUseCase : ISaveOrUpdateProjectEmployeeUseCase
    {
        private readonly IRepository _repository;

        public SaveOrUpdateProjectEmployeeUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(ProjectEmployee projectEmployee)
        {
            await _repository.SaveOrUpdateProjectEmployee(projectEmployee);
        }
    }
}
