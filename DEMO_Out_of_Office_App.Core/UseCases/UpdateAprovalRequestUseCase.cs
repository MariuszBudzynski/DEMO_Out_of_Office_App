namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class UpdateAprovalRequestUseCase : IUpdateAprovalRequestUseCase
    {
        private readonly IRepository _repository;

        public UpdateAprovalRequestUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(ApprovalRequest approvalRequest)
        {

            try
            {
                await _repository.UpdateApprovalRequest(approvalRequest);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing UpdateAprovalRequestUseCase");
                throw;
            }
        }
    }
}
