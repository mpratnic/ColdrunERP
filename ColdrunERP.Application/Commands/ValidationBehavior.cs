using FluentValidation;
using MediatR;

namespace ColdrunERP.Application.Commands
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest command, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(command);
            var errors = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors);
                
            if (errors.Any())
            {
                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
