using Agenda.DAL;
using Agenda.Domain;
using System;
using System.Collections.Generic;

namespace Agenda.Repositorio
{
    public class RepositorioContatos
    {
        private readonly IContatos _contatos;
        private readonly ITelefones _telefones;

        public RepositorioContatos(IContatos contatos, ITelefones telefones)
        {
            _contatos = contatos;
            _telefones = telefones;
        }


        public IContato ObterPorId(Guid id)
        {
            IContato contato = _contatos.Obter(id);
            IList<ITelefone> telefones = _telefones.ObterTodosDoContato(id);
            contato.Telefones = telefones;

            return contato;
        }

        public IContato ObterPorId(Func<Guid> newGuid)
        {
            throw new NotImplementedException();
        }
    }
}
