using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetAprovalRequestsByIdUseCase
    {
        Task<ApprovalRequest> ExecuteAsync(int id);
    }
}