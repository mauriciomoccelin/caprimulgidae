namespace Caprimulgidae.Domain.Models.Eventos
{
    public partial class Evento
    {
        public static Evento Criar(
            string token,
            string padrao,
            decimal probabilidadeAcontecer) =>
            new Evento
            {
                Token = token,
                Padrao = padrao,
                ProbabilidadeAcontecer = probabilidadeAcontecer,
                ProbabilidadeNaoAcontecer = 100m - probabilidadeAcontecer
            };
    }
}
