using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using FluentValidation;

namespace ColdrunERP.Application.Commands.Truck
{
    public class UpdateTruckValidator : AbstractValidator<UpdateTruckCommand>
    {
        private readonly ITruckCommandRepository _truckRepository;
        private readonly ITruckStatusCommandRepository _truckStatusRepository;
        private readonly ITruckStatusRuleCommandRepository _truckStatusRuleRepository;

        public UpdateTruckValidator(ITruckCommandRepository truckQueryRepository,
                                    ITruckStatusCommandRepository truckStatusRepository,
                                    ITruckStatusRuleCommandRepository truckStatusRuleRepository)
        {
            _truckRepository = truckQueryRepository;
            _truckStatusRepository = truckStatusRepository;
            _truckStatusRuleRepository = truckStatusRuleRepository;

            RuleFor(x => x.Code).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(1000);

            RuleFor(x => x.Code).MustAsync(async (entity, code, c) => await CheckIfCodeExists(entity.Id, code)).WithMessage("Truck code already exists.");
            RuleFor(x => x.StatusId).MustAsync(async (value, c) => await CheckIfStatusExists(value)).WithMessage("Truck status is not defined.");
            RuleFor(x => x.StatusId).MustAsync(async (entity, value, c) => await CheckIfStatusRuleExists(entity.Id, value)).WithMessage("Truck status rule is not defined.");
        }

        public async Task<bool> CheckIfCodeExists(long id, string code)
        {
            return await _truckRepository.CheckIfCodeExists(id, code);
        }

        public async Task<bool> CheckIfStatusExists(int statusId)
        {
            return await _truckStatusRepository.CheckIfExists(statusId);
        }

        public async Task<bool> CheckIfStatusRuleExists(long id, int statusId)
        {
            return await _truckStatusRuleRepository.CheckIfExists(id, statusId);
        }
    }
}
