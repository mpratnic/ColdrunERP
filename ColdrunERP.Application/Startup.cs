using ColdrunERP.Application.Commands;
using ColdrunERP.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ColdrunERP.Application
{
    public static class Startup
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(Startup).Assembly);
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddRepositoryServices();
        }
    }
}
