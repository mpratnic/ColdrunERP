using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColdrunERP.Application.Commands.Truck
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, bool>
    {
        private readonly ITruckCommandRepository _truckCommandRepository;

        public UpdateTruckCommandHandler(ITruckCommandRepository truckCommandRepository)
        {
            _truckCommandRepository = truckCommandRepository;
        }

        public async Task<bool> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Domain.Models.Truck.Truck()
            {
                Id = request.Id,
                Code = request.Code,
                Name = request.Name,
                Description = request.Description,
                StatusId = request.StatusId

            };

            return await _truckCommandRepository.Update(truck);
        }
    }
}
