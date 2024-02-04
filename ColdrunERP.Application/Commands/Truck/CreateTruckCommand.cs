using MediatR;

namespace ColdrunERP.Application.Commands.Truck
{
    public class CreateTruckCommand : IRequest<long>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
