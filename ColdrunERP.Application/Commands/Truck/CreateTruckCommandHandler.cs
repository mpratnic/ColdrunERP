using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using MediatR;

namespace ColdrunERP.Application.Commands.Truck
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, long>
    {
        private readonly ITruckCommandRepository _truckCommandRepository;

        public CreateTruckCommandHandler(ITruckCommandRepository truckCommandRepository)
        {
            _truckCommandRepository = truckCommandRepository;
        }

        public async Task<long> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Domain.Models.Truck.Truck()
            {
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId

            };            

            return await _truckCommandRepository.Create(truck);
        }
    }
}
