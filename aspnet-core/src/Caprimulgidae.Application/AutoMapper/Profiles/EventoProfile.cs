using Caprimulgidae.Application.InputModels.Eventos;
using Caprimulgidae.Domain.Commands.Eventos;

namespace Caprimulgidae.Application.AutoMapper.Profiles
{
    public class EventoProfile
    {
        public static void Map(InputModelToDomainCommand config)
        {
            config.CreateMap<CadastrarEventoInputModel, CadastrarEventoCommand>()
                .ConstructUsing(x => CadastrarEventoCommand.Criar(
                    x.Token,
                    x.Padrao,
                    x.ProbabilidadeAcontecer));
        }
    }
}
