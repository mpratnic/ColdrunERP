using ColdrunERP.Domain.Models.Truck;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public interface ITruckStatusRuleCommandRepository : ICommandRepository<TruckStatusRule, int>
    {
        Task<bool> CheckIfExists(long truckId, int truckStatusId);
    }
}
