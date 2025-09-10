using eCommerce.Core.ServiceContract;
using eCommerce.Core.Services;
using eCommerce.Core.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

    public static class DipendencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection service)
        {
            service.AddTransient<IUserService, UserService>();
            service.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return service;
        }
    }

