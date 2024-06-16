using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IGetLeaveRequestsUseCase
    {
        Task<IEnumerable<LeaveRequest>> ExecuteAsync();
    }
}