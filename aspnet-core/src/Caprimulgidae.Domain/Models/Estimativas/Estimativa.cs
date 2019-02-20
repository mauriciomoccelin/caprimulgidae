using Antilopes.Domain.Core.Models;
using System;

namespace Caprimulgidae.Domain.Models.Estimativas
{
    public partial class Estimativa : Entity<Estimativa, Guid>
    {
        #region Propriedades
        public decimal Priory { get; private set; }
        public decimal Posteriory { get; private set; }
        public decimal Probabilidade { get; private set; }
        #endregion
        #region Contrutores
        protected Estimativa() { }
        #endregion
    }
}
