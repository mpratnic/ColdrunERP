using ColdrunERP.Domain.DTOs.Truck;
using ColdrunERP.Infrastructure.Repositories.Queries.Trucks;
using MediatR;

namespace ColdrunERP.Application.Queries.Truck
{
    public class GetTruckQueryHandler : IRequestHandler<GetTruckQuery, TruckDto>
    {
        private readonly ITruckQueryRepository _truckQueryRepository;

        public GetTruckQueryHandler(ITruckQueryRepository truckQueryRepository)
        {
            _truckQueryRepository = truckQueryRepository;
        }

        public async Task<TruckDto> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            return await _truckQueryRepository.Get(request.Id);
        }
    }
}
