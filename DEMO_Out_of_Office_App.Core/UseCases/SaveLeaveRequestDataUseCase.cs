namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class SaveLeaveRequestDataUseCase : ISaveLeaveRequestDataUseCase
    {
        private readonly IRepository _repository;

        public SaveLeaveRequestDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(LeaveRequest leaveRequest)
        {
            try
            {
                await _repository.SaveLeaveRequestData(leaveRequest);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing SaveLeaveRequestDataUseCase");
                throw;
            }       
        }
    }
}
