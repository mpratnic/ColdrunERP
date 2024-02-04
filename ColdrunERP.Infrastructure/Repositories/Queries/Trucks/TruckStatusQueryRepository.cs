using ColdrunERP.Database;
using ColdrunERP.Domain.DTOs.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Queries.Trucks
{
    public class TruckStatusQueryRepository : ITruckStatusQueryRepository
    {
        private readonly ERPDbContext _db;        

        public TruckStatusQueryRepository(ERPDbContext db)
        {
            _db = db;
        }

        public async Task<TruckStatusDto> Get(int id)
        {
            var truckStatusRecord = await _db.TruckStatuses.FirstOrDefaultAsync(x => x.Id == id);
            if (truckStatusRecord is null)
            {
                return null;
            }

            var truckStatus = await Map(truckStatusRecord);
            return truckStatus;
        }

        private async Task<TruckStatusDto> Map(Database.Models.TruckStatus truckStatusRecord)
        {
            var truckStatus = new TruckStatusDto();
            truckStatus.Id = truckStatusRecord.Id;
            truckStatus.Name = truckStatusRecord.Name;
            return truckStatus;
        }
    }
}
