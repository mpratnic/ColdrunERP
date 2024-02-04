using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using MediatR;

namespace ColdrunERP.Application.Commands.Truck
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand>
    {
        private readonly ITruckCommandRepository _truckCommandRepository;

        public DeleteTruckCommandHandler(ITruckCommandRepository truckCommandRepository)
        {
            _truckCommandRepository = truckCommandRepository;
        }

        public async Task Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            await _truckCommandRepository.Delete(request.Id);
        }
    }
}