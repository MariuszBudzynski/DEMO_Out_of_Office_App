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
    public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
    {
        private readonly IRepository _repository;

        public GetAllEmployeesUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> ExecuteAsync()
        {
            return await _repository.GetEmployeesAsync();
        }
    }
}
