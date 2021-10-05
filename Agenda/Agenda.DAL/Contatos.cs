using Agenda.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Agenda.DAL
{
    public class Contatos
    {
        public void Adicionar(Contato contato)
        {

            var conexao = Conexao.AbreConexao();
            string sql = "insert into contato(id, nome) values (NEWID(), " + "'" + contato.Nome + "')";
            SqlCommand comando = new SqlCommand(sql, conexao);
            comando.ExecuteNonQuery();
        }

        public Contato Obter(string nome)
        {
            var conexao = Conexao.AbreConexao();
            string sql = "select * from contato where nome =  '" + nome + "'";
            SqlCommand comando = new SqlCommand(sql, conexao);
            var retorno = comando.ExecuteReader();
            retorno.Read();
            
            return new Contato
            {
                Id = (Guid)retorno["Id"],
                Nome = retorno["Nome"].ToString()
            };                
        }

        public IList<Contato> ObterTodos()
        {
            var listaDeContatos = new List<Contato>();
            var conexao = Conexao.AbreConexao();
            string sql = "select * from contato ";
            SqlCommand comando = new SqlCommand(sql, conexao);
            var retorno = comando.ExecuteReader();
            while (retorno.Read())
            {
                listaDeContatos.Add(new Contato
                {
                    Id = (Guid)retorno["Id"],
                    Nome = retorno["Nome"].ToString()
                });
            }
            return listaDeContatos;
        }
    }
}
