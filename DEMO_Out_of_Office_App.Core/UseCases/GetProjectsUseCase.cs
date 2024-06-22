namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetProjectsUseCase : IGetProjectsUseCase
    {
        private readonly IRepository _repository;

        public GetProjectsUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Project>> ExecuteAsync()
        {
            try
            {
                return await _repository.GetProjectsAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetProjectsUseCase");
                throw;
            }
        }
    }
}
