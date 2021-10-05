using Agenda.DAL;
using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System;

namespace Agenda.Data.Test
{
    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;
        Fixture _fixture;

        [SetUp]
        public void Setup()
        {
            _contatos = new Contatos();
            _fixture = new Fixture();
        }

        [Test]
        public void IncluirContato()
        {
            var contato = _fixture.Create<Contato>();
            _contatos.Adicionar(contato);

            Assert.True(true);
        }

        [Test]
        public void ObterContato()
        {
            var contato = _fixture.Create<Contato>();

            var nomeResultado = _contatos.Obter(contato.Id);

            Assert.AreEqual(contato.Id, nomeResultado.Id);
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
            //_fixture = null;
        }
    }
}