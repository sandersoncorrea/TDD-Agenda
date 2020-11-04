using Agenda.Domain;
using AutoFixture;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAL.Test
{
    [TestFixture]
    public class Contatos2Test : BaseTest
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
        public void ObterTodosOsContatosTest()
        {
            // Monta
            Contato contato1 = _fixture.Create<Contato>();
            Contato contato2 = _fixture.Create<Contato>();

            // Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var listContatos = _contatos.ObterTodos();
            var umContato = listContatos.Where(c => c.Id == contato1.Id).FirstOrDefault();

            // Verifica
            Assert.AreEqual(2, listContatos.Count());
            Assert.AreEqual(umContato.Id, contato1.Id);
            Assert.AreEqual(umContato.Nome, contato1.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
            _fixture = null;
        }
    }
}
