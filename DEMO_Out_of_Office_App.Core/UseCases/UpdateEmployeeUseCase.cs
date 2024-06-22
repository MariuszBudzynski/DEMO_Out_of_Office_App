namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class UpdateEmployeeUseCase : IUpdateEmployeeUseCase
    {
        private readonly IRepository _repository;

        public UpdateEmployeeUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Employee employee)
        {

            try
            {
                await _repository.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing UpdateEmployeeUseCase");
                throw;
            }
        }
    }
}
