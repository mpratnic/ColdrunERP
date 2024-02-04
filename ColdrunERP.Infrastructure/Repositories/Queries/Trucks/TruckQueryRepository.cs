using ColdrunERP.Database;
using ColdrunERP.Domain.Common;
using ColdrunERP.Domain.DTOs.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Queries.Trucks
{
    public class TruckQueryRepository : ITruckQueryRepository
    {
        private readonly ERPDbContext _db;

        public TruckQueryRepository(ERPDbContext db)
        {
            _db = db;
        }
        
        public async Task<TruckDto> Get(long id)
        {
            var truckRecord = await _db.Trucks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (truckRecord is null)
            {
                return null;
            }

            var truckStatusRecord = await _db.TruckStatuses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (truckStatusRecord is null)
            {
                return null;
            }

            var truck = await Map(truckRecord, truckStatusRecord);

            return truck;
        }

        public async Task<IEnumerable<TruckListItemDto>> GetAll(TruckListFilterBy filterBy, TruckListSortBy sortBy, Pagination pagination)
        {
            var trucks = _db.Trucks.AsNoTracking();

            if (filterBy is not null)
            {
                if (filterBy.Name is not null)
                {
                    trucks = trucks.Where(x => x.Name ==  filterBy.Name);
                }

                if (filterBy.Description is not null)
                {
                    trucks = trucks.Where(x => x.Description == filterBy.Description);
                }

                if (filterBy.StatusId is not null)
                {
                    trucks = trucks.Where(x => x.StatusId == filterBy.StatusId);
                }
            }

            if (sortBy is not null)
            {
                if (sortBy.Name is not null)
                {
                    trucks = trucks.OrderBy(x => x.Name);
                }

                if (sortBy.Description is not null)
                {
                    trucks = trucks.OrderBy(x => x.Description);
                }

                if (sortBy.StatusId is not null)
                {
                    trucks = trucks.OrderBy(x => x.StatusId);
                }
            }

            if (pagination is not null)
            {
                trucks = trucks.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
            }

            var truckStatuses = await _db.TruckStatuses.AsNoTracking().ToDictionaryAsync(x => x.Id, x => x.Name);

            return trucks.Select(x => new TruckListItemDto { Code = x.Code, Name = x.Name, Description = x.Description, StatusName = truckStatuses[x.StatusId] }).ToList() ?? new List<TruckListItemDto>();
        }

        private async Task<TruckDto> Map(Database.Models.Truck truckRecord, Database.Models.TruckStatus truckStatusRecord)
        {
            var truck = new TruckDto();
            truck.Id = truckRecord.Id;
            truck.Code = truckRecord.Code;
            truck.Name = truckRecord.Name;
            truck.Description = truckRecord.Description;
            truck.Status = new TruckStatusDto();
            truck.Status.Id = truckStatusRecord.Id;
            truck.Status.Name = truckStatusRecord.Name;
            return truck;
        }
    }
}