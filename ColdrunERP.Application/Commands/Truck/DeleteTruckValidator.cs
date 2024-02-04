using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using FluentValidation;

namespace ColdrunERP.Application.Commands.Truck
{
    public class DeleteTruckValidator : AbstractValidator<DeleteTruckCommand>
    {
        private readonly ITruckCommandRepository _truckRepository;

        public DeleteTruckValidator(ITruckCommandRepository truckQueryRepository)
        {
            _truckRepository = truckQueryRepository;

            RuleFor(x => x.Id).MustAsync(async (value, c) => await CheckTruckExists(value)).WithMessage("Truck should exist.");

        }

        public async Task<bool> CheckTruckExists(long id)
        {
            return await _truckRepository.CheckIfExists(id);
        }
    }
}