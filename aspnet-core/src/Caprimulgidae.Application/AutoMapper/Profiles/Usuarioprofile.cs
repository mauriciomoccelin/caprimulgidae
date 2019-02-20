using Caprimulgidae.Application.InputModels.Usuarios;
using Caprimulgidae.Domain.Commands.Usuarios;

namespace Caprimulgidae.Application.AutoMapper.Profiles
{
    public class UsuarioProfile
    {
        public static void Map(InputModelToDomainCommand config)
        {
            config.CreateMap<RegistrarUsuarioInputModel, RegistrarUsuarioCommand>()
                .ConstructUsing(x => RegistrarUsuarioCommand.Criar(
                    x.PrimeiroNome,
                    x.SegundoNome,
                    x.Email,
                    x.Senha));
        }
    }
}
