namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class UpdateProjectDataUseCase : IUpdateProjectDataUseCase
    {
        private readonly IRepository _repository;

        public UpdateProjectDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Project project)
        {
            try
            {
                await _repository.UpdateProjectData(project);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing UpdateProjectDataUseCase");
                throw;
            }
        }
    }
}
