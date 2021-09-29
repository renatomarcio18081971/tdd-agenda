using System;
using NUnit.Framework;

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
            string id = Guid.NewGuid().ToString();
            string nome = "carlos";

            _contatos.Adicionar(id, nome);

            Assert.True(true);
        }

        [Test]
        public void ObterContato()
        {

        }


        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
