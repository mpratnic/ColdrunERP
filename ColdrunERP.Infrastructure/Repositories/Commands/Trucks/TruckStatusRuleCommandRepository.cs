using ColdrunERP.Database;
using ColdrunERP.Domain.Models.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public class TruckStatusRuleCommandRepository : ITruckStatusRuleCommandRepository
    {
        private readonly ERPDbContext _db;

        public TruckStatusRuleCommandRepository(ERPDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfExists(int id)
        {
            return await _db.TruckStatusRules.AnyAsync(x => x.Id == id);
        }

        public async Task<bool> CheckIfExists(long truckId, int truckStatusId)
        {
            var statusIdFrom = await _db.Trucks.Where(x => x.Id == truckId).Select(x => x.StatusId).FirstOrDefaultAsync();
            return await _db.TruckStatusRules.AnyAsync(x => x.StatusIdFrom == statusIdFrom && x.StatusIdTo == truckStatusId);
        }

        public async Task<int> Create(TruckStatusRule truckStatusRule)
        {
            var truckStatusRuleRecord = await Map(truckStatusRule);
            _db.TruckStatusRules.Add(truckStatusRuleRecord);
            await _db.SaveChangesAsync();
            return truckStatusRuleRecord.Id;
        }

        public async Task Delete(int id)
        {
            var truckStatusRuleRecord = await _db.TruckStatusRules.FirstOrDefaultAsync(x => x.Id == id);
            if (truckStatusRuleRecord is not null)
            {
                _db.TruckStatusRules.Remove(truckStatusRuleRecord);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> Update(TruckStatusRule truckStatusRule)
        {
            var truckStatusRuleRecord = await _db.TruckStatusRules.FirstOrDefaultAsync(x => x.Id == truckStatusRule.Id);
            if (truckStatusRuleRecord is null)
            {
                return false;
            }

            truckStatusRuleRecord.StatusIdFrom = truckStatusRule.StatusIdFrom;
            truckStatusRuleRecord.StatusIdTo = truckStatusRule.StatusIdTo;
            await _db.SaveChangesAsync();
            return true;
        }

        private async Task<Database.Models.TruckStatusRule> Map(TruckStatusRule truckStatusRule)
        {
            return new Database.Models.TruckStatusRule
            {
                Id = truckStatusRule.Id,
                StatusIdFrom = truckStatusRule.StatusIdFrom,
                StatusIdTo = truckStatusRule.StatusIdTo
            };
        }
    }
}