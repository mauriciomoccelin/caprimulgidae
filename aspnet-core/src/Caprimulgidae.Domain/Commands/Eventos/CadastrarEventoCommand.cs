using Caprimulgidae.Domain.Validations.Eventos;

namespace Caprimulgidae.Domain.Commands.Eventos
{
    public sealed class CadastrarEventoCommand : EventoCommand
    {
        private CadastrarEventoCommand() { }

        public static CadastrarEventoCommand Criar(
            string token,
            string padrao,
            decimal probabilidadeAcontecer) =>
            new CadastrarEventoCommand()
            {
                Token = token,
                Padrao = padrao,
                ProbabilidadeAcontecer = probabilidadeAcontecer
            };

        public override bool IsValid()
        {
            ValidationResult = new CadastrarEventoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
