using Agenda.DAL;
using Agenda.Domain;
using Agenda.Repositorio;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Agenda.Repositorios.Test
{
    [TestFixture]
    public class RepositorioContatosTest
    {
        Mock<IContatos> _contatos;
        Mock<ITelefones> _telefones;
        RepositorioContatos _repositorioContatos;


        [SetUp]
        public void SetUp()
        {
            _contatos = new Mock<IContatos>();
            _telefones = new Mock<ITelefones>();
            _repositorioContatos = new RepositorioContatos(_contatos.Object, _telefones.Object);
        }


        [Test]
        public void DeveSerPossivelObterContatoComListaDeTelefones()
        {
            Guid telefoneId = Guid.NewGuid();
            Guid contatoId = Guid.NewGuid();
            List<ITelefone> listaDeTelefone = new();
            Mock<IContato> mockContato = new();
            mockContato.SetupGet(a => a.Id).Returns(contatoId);
            mockContato.SetupGet(a => a.Nome).Returns("Joao");
            //mockContato.SetupSet(a => a.Telefones = It.IsAny<List<ITelefone>>()).Callback<List<ITelefone>>(p => listaDeTelefone = p);

            _contatos.Setup(a => a.Obter(contatoId)).Returns(mockContato.Object);

            Mock<ITelefone> mockTelefone = new Mock<ITelefone>();
            mockTelefone.SetupGet(a => a.Id).Returns(telefoneId);
            mockTelefone.SetupGet(a => a.Numero).Returns("998168510");
            mockTelefone.SetupGet(a => a.ContatoId).Returns(contatoId);

            _telefones.Setup(a => a.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mockTelefone.Object });
            IContato contatoResultado = _repositorioContatos.ObterPorId(contatoId);
            mockContato.SetupGet(a => a.Telefones).Returns(listaDeTelefone);
            Assert.AreEqual(mockContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mockContato.Object.Nome, contatoResultado.Nome);
            //Assert.AreEqual(1, contatoResultado.Telefones.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _telefones = null;
            _repositorioContatos = null;
        }

    }
}
