using Agenda.DAL;
using Agenda.Domain;
using NUnit.Framework;
using System;
using System.Linq;

namespace Agenda.Data.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;

        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
        }

        [Test]
        public void IncluirContato()
        {
            var contato = new Contato
            {
                Id = Guid.NewGuid(),
                Nome = "carlos"
            };
            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContato()
        {
            string nome = "carlos";

            var nomeResultado = _contatos.Obter(nome);

            Assert.AreEqual(nome, nomeResultado.Nome);
        }

        [Test]
        public void ObterTodosContatosTest()
        {
            var lista = _contatos.ObterTodos();
            Assert.IsTrue(lista.Count > 1);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}