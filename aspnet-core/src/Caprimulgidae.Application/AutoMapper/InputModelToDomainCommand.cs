using AutoMapper;
using Caprimulgidae.Application.AutoMapper.Profiles;

namespace Caprimulgidae.Application.AutoMapper
{
    public class InputModelToDomainCommand : Profile
    {
        public InputModelToDomainCommand()
        {
            EventoProfile.Map(this);
            UsuarioProfile.Map(this);
        }
    }
}
