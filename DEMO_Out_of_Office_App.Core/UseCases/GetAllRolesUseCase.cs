namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllRolesUseCase : IGetAllRolesUseCase
    {
        private readonly IRepository _repository;

        public GetAllRolesUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Role>> ExecuteAsync()
        {
            try
            {
                return await _repository.GetData<Role>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAllRolesUseCase");
                throw;
            }
        }
    }
}
