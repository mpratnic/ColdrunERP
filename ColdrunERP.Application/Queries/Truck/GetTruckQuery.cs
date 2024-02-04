using ColdrunERP.Domain.DTOs.Truck;
using MediatR;

namespace ColdrunERP.Application.Queries.Truck
{
    public class GetTruckQuery : IRequest<TruckDto>
    {
        public long Id { get; set; }
    }
}
