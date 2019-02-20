using Antilopes.Identity;
using Antilopes.Identity.Filters;
using Caprimulgidae.Domain.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Security.Claims;

namespace Caprimulgidae.Infra.CrossCutting.IoC
{
    public sealed class IdentityServices
    {
        public static void Register(
            IServiceCollection services,
            IConfiguration configuration)
        {
            var claims = new List<ClaimRequirement>();
            foreach (var permissaoValor in typeof(PermissaoEnum).GetEnumValues())
            {
                var permissaoNome = permissaoValor.ToString();
                claims.Add(ClaimRequirement.Create(permissaoNome, ClaimTypes.Role, permissaoNome));
            }
            services.AddIdentity(configuration, claims);
        }
    }
}
