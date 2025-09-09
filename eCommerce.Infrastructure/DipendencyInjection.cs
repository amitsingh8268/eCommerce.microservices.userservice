using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DipendencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IUserRepository, UserRepository>();
        service.AddTransient<DapperDbContext>();
        return service;
    }
}

