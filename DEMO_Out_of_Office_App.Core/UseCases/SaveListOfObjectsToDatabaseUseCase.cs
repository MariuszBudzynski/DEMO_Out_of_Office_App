namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class SaveListOfObjectsToDatabaseUseCase : ISaveListOfObjectsToDatabaseUseCase
    {
        private readonly IRepository _repository;

        public SaveListOfObjectsToDatabaseUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync<T>(IEnumerable<T> objectList) where T : class, IEntityId
        {

            try
            {
                await _repository.SaveListOfObjectsToDatabase(objectList);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing SaveListOfObjectsToDatabaseUseCase");
                throw;
            }           
        }
    }
}
