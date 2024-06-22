namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAprovalRequestsUseCase : IGetAprovalRequestsUseCase
    {
        private readonly IRepository _repository;

        public GetAprovalRequestsUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ApprovalRequest>> ExecuteAsync()
        {
            try
            {
                return (await _repository.GetEmpAprovalRequestsAsync()).ToList();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAprovalRequestsUseCase");
                throw;
            }
        }
    }
}
