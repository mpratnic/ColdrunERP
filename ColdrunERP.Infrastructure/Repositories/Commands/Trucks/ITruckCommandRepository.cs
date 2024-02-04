using ColdrunERP.Domain.Models.Truck;

namespace ColdrunERP.Infrastructure.Repositories.Commands.Trucks
{
    public interface ITruckCommandRepository : ICommandRepository<Truck, long>
    {
        Task<bool> CheckIfCodeExists(string code);
        Task<bool> CheckIfCodeExists(long id, string code);
    }
}