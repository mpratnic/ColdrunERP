using ColdrunERP.Domain.Common;
using ColdrunERP.Domain.DTOs.Truck;
using ColdrunERP.Infrastructure.Repositories.Queries.Trucks;
using MediatR;

namespace ColdrunERP.Application.Queries.Truck
{
    public class GetTruckListQueryHandler : IRequestHandler<GetTruckListQuery, IEnumerable<TruckListItemDto>>
    {
        private readonly ITruckQueryRepository _truckQueryRepository;

        public GetTruckListQueryHandler(ITruckQueryRepository truckQueryRepository)
        {
            _truckQueryRepository = truckQueryRepository;
        }

        public async Task<IEnumerable<TruckListItemDto>> Handle(GetTruckListQuery request, CancellationToken cancellationToken)
        {
            var trucksListFilterBy = new TruckListFilterBy
            {
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId
            };

            var trucksListSortBy = new TruckListSortBy
            {
                Name = request.SortByName,
                Description = request.SortByDescription,
                StatusId = request.SortByStatus
            };

            var pagination = new Pagination
            {
                 PageNumber = request.PageNumber,
                 PageSize = request.PageSize
            };

            return await _truckQueryRepository.GetAll(trucksListFilterBy, trucksListSortBy, pagination);
        }
    }
}
