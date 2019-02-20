using Antilopes.Domain.Core.Models;
using Caprimulgidae.Domain.Models.Eventos;
using System;
using System.Collections.Generic;

namespace Caprimulgidae.Domain.Models.AreasConhecimentos
{
    public partial class AreaConhecimento : Entity<AreaConhecimento, Guid>
    {
        #region Propriedades
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        #region Propriedades de Navegação
        public ICollection<Evento> Eventos { get; private set; }
        #endregion
        #endregion
        #region Construtores
        protected AreaConhecimento() { }
        #endregion
    }
}
