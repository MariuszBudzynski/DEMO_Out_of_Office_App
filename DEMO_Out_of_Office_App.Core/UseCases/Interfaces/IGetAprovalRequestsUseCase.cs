using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAprovalRequestsUseCase
    {
        Task<List<ApprovalRequest>> ExecuteAsync();
    }
}