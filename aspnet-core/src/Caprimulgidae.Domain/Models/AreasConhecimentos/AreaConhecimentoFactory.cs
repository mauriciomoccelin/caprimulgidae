namespace Caprimulgidae.Domain.Models.AreasConhecimentos
{
    public partial class AreaConhecimento
    {
        public static AreaConhecimento CriarParaCadastrar(
            string nome,
            string descricao) =>
            new AreaConhecimento()
            {
                Nome = nome,
                Descricao = descricao,
            };
    }
}
