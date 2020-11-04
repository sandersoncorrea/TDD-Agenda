using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class ContatosTest : BaseTest
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
        public void AdicionarContatoTest()
        {
            // Monta
            var contato = _fixture.Create<Contato>();

            // Executa
            _contatos.Adicionar(contato);

            // Verifica
            Assert.True(true);

        }

        [Test]
        public void ObterContatoTest()
        {
            // Monta
            Contato contato = _fixture.Create<Contato>();
            Contato contatoResultado;

            // Executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            // Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
