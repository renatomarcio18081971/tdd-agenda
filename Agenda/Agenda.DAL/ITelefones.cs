using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public interface ITelefones
    {
        IList<ITelefone> Obter(Guid contatoId);
        IList<ITelefone> ObterTodosDoContato(Guid id);
    }
}
