using MediatR;

namespace ColdrunERP.Application.Commands.Truck
{
    public class UpdateTruckCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
