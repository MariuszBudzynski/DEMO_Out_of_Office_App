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
    public class GetLeaveRequestsUseCase : IGetLeaveRequestsUseCase
    {
        private readonly IRepository _repository;

        public GetLeaveRequestsUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveRequest>> ExecuteAsync()
        {
            return await _repository.GetLeaveRequestsAsync();
        }
    }
}
