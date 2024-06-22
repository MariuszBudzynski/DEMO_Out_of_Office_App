namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetLeaveRequestsUseCase : IGetLeaveRequestsUseCase
    {
        private readonly IRepository _repository;

        public GetLeaveRequestsUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeaveRequest>> ExecuteAsync()
        {

            try
            {
                return await _repository.GetLeaveRequestsAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetLeaveRequestsUseCase");
                throw;
            }
        }
    }
}
