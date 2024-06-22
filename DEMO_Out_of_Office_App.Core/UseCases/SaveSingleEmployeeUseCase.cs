namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class SaveSingleEmployeeUseCase : ISaveSingleEmployeeUseCase
    {
        private readonly IRepository _repository;

        public SaveSingleEmployeeUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Employee employee)
        {
            try
            {
                await _repository.SaveEmployeeData(employee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing SaveSingleEmployeeUseCase");
                throw;
            }
        }
    }
}
