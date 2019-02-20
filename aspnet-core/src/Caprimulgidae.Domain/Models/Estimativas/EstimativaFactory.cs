namespace Caprimulgidae.Domain.Models.Estimativas
{
    public partial class Estimativa
    {
        internal static Estimativa CriarEstimativaPorTeoremaBayes(
            decimal priory,
            decimal posteriory) =>
            new Estimativa()
            {
                Priory = priory,
                Posteriory = posteriory
            }.Calcular();

        private Estimativa Calcular()
        {
            Probabilidade = Priory / (Priory * Posteriory);
            return this;
        }
    }
}
