using ColdrunERP.Database;
using ColdrunERP.Domain.Models.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public class TruckStatusCommandRepository : ITruckStatusCommandRepository
    {
        private readonly ERPDbContext _db;

        public TruckStatusCommandRepository(ERPDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfExists(int id)
        {
            return await _db.TruckStatuses.AnyAsync(x => x.Id == id);
        }

        public async Task<int> Create(TruckStatus truckStatus)
        {
            var truckStatusRecord = await Map(truckStatus);
            _db.TruckStatuses.Add(truckStatusRecord);
            await _db.SaveChangesAsync();
            return truckStatusRecord.Id;
        }

        public async Task Delete(int id)
        {
            var truckStatusRecord = await _db.TruckStatuses.FirstOrDefaultAsync(x => x.Id == id);
            if (truckStatusRecord is not null)
            {
                _db.TruckStatuses.Remove(truckStatusRecord);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(TruckStatus truckStatus)
        {
            var truckStatusRecord = await _db.TruckStatuses.FirstOrDefaultAsync(x => x.Id == truckStatus.Id);
            if (truckStatusRecord is null)
            {
                return false;
            }

            truckStatusRecord.Name = truckStatus.Name;
            await _db.SaveChangesAsync();
            return true;
        }

        private async Task<Database.Models.TruckStatus> Map(TruckStatus truckStatus)
        {
            return new Database.Models.TruckStatus
            {
                Id = truckStatus.Id,
                Name = truckStatus.Name,
            };
        }
    }
}
