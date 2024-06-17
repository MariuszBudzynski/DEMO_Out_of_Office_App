using DEMOOutOfOfficeApp.Core.Entities;

namespace DEMOOutOfOfficeApp.Core.UseCases.Interfaces
{
    public interface IUpdateLeaveRequestUseCase
    {
        Task ExecureAsync(LeaveRequest leaveRequest);
    }
}