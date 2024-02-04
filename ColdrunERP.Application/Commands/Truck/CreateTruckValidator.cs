using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using FluentValidation;

namespace ColdrunERP.Application.Commands.Truck
{
    public class CreateTruckValidator : AbstractValidator<CreateTruckCommand>
    {
        private readonly ITruckCommandRepository _truckRepository;
        private readonly ITruckStatusCommandRepository _truckStatusRepository;

        public CreateTruckValidator(ITruckCommandRepository truckRepository, ITruckStatusCommandRepository truckStatusRepository)
        {
            _truckRepository = truckRepository;
            _truckStatusRepository = truckStatusRepository;

            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(1000);

            RuleFor(x => x.Code).MustAsync(async (value, c) => await CheckIfCodeExists(value)).WithMessage("Truck code already exists.");
            RuleFor(x => x.StatusId).MustAsync(async (value, c) => await CheckIfStatusExists(value)).WithMessage("Truck status is not defined.");
        }

        public async Task<bool> CheckIfCodeExists(string code)
        {            
            return await _truckRepository.CheckIfCodeExists(code);
        }

        public async Task<bool> CheckIfStatusExists(int statusId)
        {
            return await _truckStatusRepository.CheckIfExists(statusId);
        }
    }
}
