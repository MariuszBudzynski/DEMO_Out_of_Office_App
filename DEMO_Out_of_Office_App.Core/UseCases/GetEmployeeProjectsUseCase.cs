namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetEmployeeProjectsUseCase : IGetEmployeeProjectsUseCase
    {
        private readonly IRepository _repository;

        public GetEmployeeProjectsUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProjectEmployee>> ExecuteAsync()
        {

            try
            {
                return await _repository.GetEmployeeProjects();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetEmployeeProjectsUseCase");
                throw;
            }            
        }
    }
}
