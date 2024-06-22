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

            try
            {
                await _repository.UpdateLeaveRequest(leaveRequest);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing UpdateLeaveRequestUseCase");
                throw;
            }
        }
    }
}
