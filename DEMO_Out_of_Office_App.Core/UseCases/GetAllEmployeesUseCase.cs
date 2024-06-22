namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllEmployeesUseCase : IGetAllEmployeesUseCase
    {
        private readonly IRepository _repository;

        public GetAllEmployeesUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Employee>> ExecuteAsync()
        {
            try
            {
                return await _repository.GetEmployeesAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAllEmployeesUseCase");
                throw;
            }            
        }
    }
}
