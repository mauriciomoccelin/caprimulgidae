﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caprimulgidae.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            IdentityServices.Register(services, configuration);
            DomainServices.Register(services);
            RepositoryServices.Register(services, configuration);
            ApplicationServices.Register(services);
        }
    }
}
