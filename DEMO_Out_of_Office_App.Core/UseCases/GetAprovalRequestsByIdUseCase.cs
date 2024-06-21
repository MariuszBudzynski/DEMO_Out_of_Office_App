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
    public class GetAprovalRequestsByIdUseCase : IGetAprovalRequestsByIdUseCase
    {
        private readonly IRepository _repository;

        public GetAprovalRequestsByIdUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApprovalRequest> ExecuteAsync(int id)
        {
            return await _repository.GetAprovalRequestsByIdAsync(id);
        }
    }
}
