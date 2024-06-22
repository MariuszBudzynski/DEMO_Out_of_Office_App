namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetDataByIdUseCase : IGetDataByIdUseCase
    {
        private readonly IRepository _repository;

        public GetDataByIdUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> ExecuteAsync<T>(int id) where T : class, IEntityId
        {
            try
            {
                return await _repository.GetDataById<T>(id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetDataByIdUseCase");
                throw;
            }            
        }
    }
}
