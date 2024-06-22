namespace DEMOOutOfOfficeApp.Core.UseCases
{
    public class GetAllSubdivisionUseCase : IGetAllSubdivisionsUseCase
    {
        private readonly IRepository _repository;

        public GetAllSubdivisionUseCase(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Subdivision>> ExecuteAsync()
        {

            try
            {
                return await _repository.GetData<Subdivision>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while executing GetAllSubdivisionUseCase");
                throw;
            }
        }
    }
}
