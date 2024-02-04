using ColdrunERP.Database;
using ColdrunERP.Infrastructure.Repositories.Commands.Trucks;
using ColdrunERP.Infrastructure.Repositories.Queries.Trucks;
using Microsoft.Extensions.DependencyInjection;

namespace ColdrunERP.Infrastructure
{
    public static class Startup
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddDbContext<ERPDbContext>();
            services.AddTransient<ITruckQueryRepository, TruckQueryRepository>();
            services.AddTransient<ITruckStatusQueryRepository, TruckStatusQueryRepository>();
            services.AddTransient<ITruckStatusRuleQueryRepository, TruckStatusRuleQueryRepository>();
            services.AddTransient<ITruckCommandRepository, TruckCommandRepository>();
            services.AddTransient<ITruckStatusCommandRepository, TruckStatusCommandRepository>();
            services.AddTransient<ITruckStatusRuleCommandRepository, TruckStatusRuleCommandRepository>();
        }
    }
}