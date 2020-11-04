using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain;
using Agenda.DAL;
using Agenda.Repos;
using NUnit.Framework;
using Moq;

namespace Agenda.Respos.Test
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
        public void DeveSerPossivelObterContatoComListaTelefonica()
        {
            // Montar
            Guid telefoneId = Guid.NewGuid();
            Guid contatoId = Guid.NewGuid();
            List<ITelefone> lstTelefone = new List<ITelefone>();
            Mock<IContato> mContato = new Mock<IContato>();
            mContato.SetupGet(o => o.Id).Returns(contatoId);
            mContato.SetupGet(o => o.Nome).Returns("João");
            mContato.SetupSet(o => o.Telefones = It.IsAny<List<ITelefone>>())
                .Callback<List<ITelefone>>(p => lstTelefone = p);

            _contatos.Setup(o => o.Obter(contatoId)).Returns(mContato.Object);

            Mock<ITelefone> mTelefone = new Mock<ITelefone>();
            mTelefone.SetupGet(o => o.Id).Returns(telefoneId);
            mTelefone.SetupGet(o => o.Numero).Returns("1234-1234");
            mTelefone.SetupGet(o => o.ContatoId).Returns(contatoId);

            _telefones.Setup(o => o.ObterTodosDoContato(contatoId)).Returns(new List<ITelefone> { mTelefone.Object });

            // Executar
            var contatoResultado = _repositorioContatos.ObterPorId(Guid.NewGuid());
            mContato.SetupGet(o => o.Telefones).Returns(lstTelefone);

            // Verificar
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Id);
            Assert.AreEqual(mContato.Object.Nome, contatoResultado.Nome);
            Assert.AreEqual(1, contatoResultado.Telefones.Count);
            Assert.AreEqual(mTelefone.Object.Numero, contatoResultado.Telefones[0].Numero);
            Assert.AreEqual(mTelefone.Object.Id, contatoResultado.Telefones[0].Id);
            Assert.AreEqual(mContato.Object.Id, contatoResultado.Telefones[0].ContatoId);
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
