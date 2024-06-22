namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IRepository _repository;

        public GetAllUsersUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> ExecuteAsync() 
        {
            try
            {
                return await _repository.GetUsersAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAllUsersUseCase");
                throw;
            }

        }
    }
}
