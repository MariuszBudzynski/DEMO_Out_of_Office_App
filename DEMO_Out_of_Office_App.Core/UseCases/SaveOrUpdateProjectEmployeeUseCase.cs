namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class SaveOrUpdateProjectEmployeeUseCase : ISaveOrUpdateProjectEmployeeUseCase
    {
        private readonly IRepository _repository;

        public SaveOrUpdateProjectEmployeeUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(ProjectEmployee projectEmployee)
        {
            try
            {
                await _repository.SaveOrUpdateProjectEmployee(projectEmployee);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing SaveOrUpdateProjectEmployeeUseCase");
                throw;
            }           
        }
    }
}
