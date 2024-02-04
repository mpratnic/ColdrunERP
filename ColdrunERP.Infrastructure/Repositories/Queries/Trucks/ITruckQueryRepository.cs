using ColdrunERP.Domain.Common;
using ColdrunERP.Domain.DTOs.Truck;

namespace ColdrunERP.Infrastructure.Repositories.Queries.Trucks
{
    public interface ITruckQueryRepository : IQueryRepository<TruckDto, long>
    {
        Task<IEnumerable<TruckListItemDto>> GetAll(TruckListFilterBy filterBy, TruckListSortBy sortBy, Pagination pagination);
    }
}
