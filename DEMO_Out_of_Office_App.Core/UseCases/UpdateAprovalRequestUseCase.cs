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
    public class UpdateAprovalRequestUseCase : IUpdateAprovalRequestUseCase
    {
        private readonly IRepository _repository;

        public UpdateAprovalRequestUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(ApprovalRequest approvalRequest)
        {
            await _repository.UpdateApprovalRequest(approvalRequest);
        }
    }
}
