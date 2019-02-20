using AutoMapper;

namespace Caprimulgidae.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.AddProfile(new InputModelToDomainCommand());
        }
    }
}
