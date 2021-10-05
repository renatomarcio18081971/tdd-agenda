using Agenda.Domain;
using NUnit.Framework;
using System;

namespace Agenda.DAL.Test
{

    [TestFixture]
    public class ContatosTest
    {
        Contatos _contatos;


        [SetUp]
        public void SetUp()
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

            Assert.AreEqual(nome, nomeResultado);
        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
