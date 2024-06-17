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
    public class UpdateLeaveRequestUseCase : IUpdateLeaveRequestUseCase
    {
        private readonly IRepository _repository;

        public UpdateLeaveRequestUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecureAsync(LeaveRequest leaveRequest)
        {
            await _repository.UpdateLeaveRequest(leaveRequest);
        }
    }
}
