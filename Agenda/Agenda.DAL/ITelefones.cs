using System;
using System.Collections.Generic;

namespace Agenda.DAL
{
    public interface ITelefones
    {
        IList<ITelefones> Obter(Guid contatoId);
    }
}
