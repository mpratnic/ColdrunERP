using ColdrunERP.Database;
using ColdrunERP.Domain.DTOs.Truck;
using ColdrunERP.Domain.Models.Truck;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Infrastructure.Repositories.Queries.Trucks
{
    public class TruckStatusRuleQueryRepository : ITruckStatusRuleQueryRepository
    {
        private readonly ERPDbContext _db;        

        public TruckStatusRuleQueryRepository(ERPDbContext db)
        {
            _db = db;            
        }

        public async Task<TruckStatusRuleDto> Get(int id)
        {
            var truckStatusRuleRecord = await _db.TruckStatusRules.FirstOrDefaultAsync(x => x.Id == id);
            if (truckStatusRuleRecord is null)
            {
                return null;
            }

            var truckStatusRule = await Map(truckStatusRuleRecord);
            return truckStatusRule;
        }

        private async Task<TruckStatusRuleDto> Map(Database.Models.TruckStatusRule truckStatusRuleRecord)
        {
            return new TruckStatusRuleDto
            {
                Id = truckStatusRuleRecord.Id,
                StatusIdFrom = truckStatusRuleRecord.StatusIdFrom,
                StatusIdTo = truckStatusRuleRecord.StatusIdTo
            };
        }
    } 
}