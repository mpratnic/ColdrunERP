using MediatR;

namespace ColdrunERP.Application.Commands.Truck
{
    public class DeleteTruckCommand : IRequest
    {
        public long Id { get; set; }
    }
}
