namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllStatusesUseCase : IGetAllStatusesUseCase
    {
        private readonly IRepository _repository;

        public GetAllStatusesUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeStatus>> ExecuteAsync()
        {
            try
            {
                return await _repository.GetData<EmployeeStatus>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAllStatusesUseCase");
                throw;
            }
        }
    }
}
