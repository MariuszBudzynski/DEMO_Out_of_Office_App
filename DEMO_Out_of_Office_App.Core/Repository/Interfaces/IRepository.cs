using DEMOOutOfOfficeApp.Common.Interfaces;

namespace DEMOOutOfOfficeApp.Core.Repository.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<T>> GetData<T>() where T : class, IEntityId;
    }
}