using ColdrunERP.Domain.Models.Truck;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public interface ITruckStatusCommandRepository : ICommandRepository<TruckStatus, int>
    {
    }
}
