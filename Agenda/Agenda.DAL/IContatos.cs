using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public interface IContatos
    {
        IList<ITelefone> Telefones { get; set; }
        IContato Obter(Guid id);
    }
}
