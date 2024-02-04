using ColdrunERP.Database;
using ColdrunERP.Domain.Models.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public class TruckCommandRepository : ITruckCommandRepository
    {
        private readonly ERPDbContext _db;

        public TruckCommandRepository(ERPDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfCodeExists(string code)
        {
            return await _db.Trucks.AnyAsync(x => x.Code == code);
        }

        public async Task<bool> CheckIfCodeExists(long id, string code)
        {
            return await _db.Trucks.AnyAsync(x => x.Id != id && x.Code == code);
        }

        public async Task<bool> CheckIfExists(long id)
        {
            return await _db.Trucks.AnyAsync(x => x.Id == id);
        }

        public async Task<long> Create(Truck truck)
        {
            var truckRecord = await Map(truck);
            _db.Trucks.Add(truckRecord);
            await _db.SaveChangesAsync();
            return truckRecord.Id;
        }

        public async Task Delete(long id)
        {
            var truckRecord = await _db.Trucks.FirstOrDefaultAsync(x => x.Id == id);
            if (truckRecord is not null)
            {
                _db.Trucks.Remove(truckRecord);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(Truck truck)
        {
            var truckRecord = await _db.Trucks.FirstOrDefaultAsync(x => x.Id == truck.Id);
            if (truckRecord is null)
            {
                return false;
            }

            truckRecord.Code = truck.Code;
            truckRecord.Name = truck.Name;
            truckRecord.Description = truck.Description;
            truckRecord.StatusId = truck.StatusId;
            await _db.SaveChangesAsync();
            return true;
        }

        private async Task<Database.Models.Truck> Map(Truck truck)
        {
            return new Database.Models.Truck()
            {
                Id = truck.Id,
                Code = truck.Code,
                Name = truck.Name,
                Description = truck.Description,
                StatusId = truck.StatusId
            };
        }
    }
}