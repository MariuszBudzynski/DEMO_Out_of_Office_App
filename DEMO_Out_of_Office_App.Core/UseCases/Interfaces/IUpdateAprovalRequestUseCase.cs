using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IUpdateAprovalRequestUseCase
    {
        Task ExecuteAsync(ApprovalRequest approvalRequest);
    }
}