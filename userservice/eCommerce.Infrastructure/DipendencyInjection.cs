using eCommerce.Core.RepositoryContract;
using eCommerce.Core.SecurityContract;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DipendencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddTransient<IUserRepository, UserRepository>();
        service.AddTransient<DapperDbContext>();
        service.AddTransient<IPasswordHasher, BCryptPasswordHasher>();
        service.AddTransient<IToken, JwtTokenService>();
        return service;
    }
}

