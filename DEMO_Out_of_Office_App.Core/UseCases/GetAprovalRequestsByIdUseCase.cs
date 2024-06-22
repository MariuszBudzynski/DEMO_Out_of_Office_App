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
            try
            {
                return await _repository.GetAprovalRequestsByIdAsync(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAprovalRequestsByIdUseCase");
                throw;
            }
        }
    }
}
