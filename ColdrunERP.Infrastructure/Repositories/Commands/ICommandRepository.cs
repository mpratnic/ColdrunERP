namespace ColdrunERP.Infrastructure.Repositories.Commands
{
    public interface ICommandRepository<T, TId> where T : class where TId : notnull
    {
        Task<bool> CheckIfExists(TId id);

        Task<TId> Create(T item);

        Task<bool> Update(T item);

        Task Delete(TId id);
    }
}
