namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetDataUseCase : IGetDataUseCase
    {
        private readonly IRepository _repository;

        public GetDataUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> ExecuteAsync<T>() where T : class, IEntityId
        {
            try
            {
                return await _repository.GetData<T>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetDataUseCase");
                throw;
            }

        }
    }
}
