namespace ColdrunERP.Infrastructure.Repositories.Queries
{
    public interface IQueryRepository<T, TId> where T : class where TId : notnull
    {
        Task<T> Get(TId id);
    }
}
