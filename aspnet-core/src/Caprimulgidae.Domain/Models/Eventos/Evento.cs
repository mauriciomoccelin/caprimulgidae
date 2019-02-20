using Antilopes.Domain.Core.Models;
using Caprimulgidae.Domain.Models.AreasConhecimentos;
using System;

namespace Caprimulgidae.Domain.Models.Eventos
{
    public partial class Evento : Entity<Evento, Guid>
    {
        #region Propriedades
        public string Token { get; private set; }
        public string Padrao { get; private set; }
        public decimal ProbabilidadeAcontecer { get; private set; }
        public decimal ProbabilidadeNaoAcontecer { get; private set; }
        public virtual Guid IdAreaConhecimento { get; private set; }
        public virtual AreaConhecimento AreaConhecimento { get; private set; }
        #endregion
        #region Construtores
        protected Evento() { }
        #endregion
    }
}
