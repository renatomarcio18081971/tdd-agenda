using Agenda.Domain;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Agenda.DAL
{
    public class Contatos
    {
        public void Adicionar(Contato contato)
        {
            var conexao = Conexao.AbreConexao();
            string sql = "insert into contato(id, nome) values (NEWID(), " + "'" + contato.Nome + "')";
            conexao.Execute(sql);
        }

        public Contato Obter(string nome)
        {
            var conexao = Conexao.AbreConexao();
            Contato contato = conexao.QueryFirst<Contato>("select * from contato where nome = @nome ", new { nome = nome });
            return contato;           
        }

        public IList<Contato> ObterTodos()
        {
            var conexao = Conexao.AbreConexao();

            var listaDeContatos = conexao.Query<Contato>("select * from contato ").ToList();
            return listaDeContatos;
        }

    }
}
