using Agenda.DAL;
using Agenda.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repositorio.Test
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
            Mock<IContato> mockContato = new Mock<IContato>();
            mockContato.SetupGet(a => a.Id).Returns(Guid.NewGuid());
            mockContato.SetupGet(a => a.Nome).Returns("Joao");

            
            _contatos.Setup(a => a.Obter(It.IsAny<Guid>())).Returns(mockContato.Object);

            Mock<ITelefone> mockTelefone = new Mock<ITelefone>();
            mockTelefone.SetupGet(a => a.Id).Returns(Guid.NewGuid);
            mockTelefone.SetupGet(a => a.Numero).Returns("998168510");
            mockTelefone.SetupGet(a => a.ContatoId).Returns(Guid.NewGuid);

            _telefones.Setup(a => a.ObterTodosDoContato(It.IsAny<Guid>())).Returns(new List<ITelefone> { mockTelefone.Object });
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
