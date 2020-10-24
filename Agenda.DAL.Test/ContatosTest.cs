using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Domain;
using NUnit.Framework;

namespace Agenda.DAL.Test
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
        public void AdicionarContatoTest()
        {
            // Monta
            var contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Defante"
            };

            // Executa
            _contatos.Adicionar(contato);

            // Verifica
            Assert.True(true);

        }

        [Test]
        public void ObterContatoTest()
        {
            // Monta
            Contato contato = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Defante"
            };
            Contato contatoResultado;

            // Executa
            _contatos.Adicionar(contato);
            contatoResultado = _contatos.Obter(contato.Id);

            // Verifica
            Assert.AreEqual(contato.Id, contatoResultado.Id);
            Assert.AreEqual(contato.Nome, contatoResultado.Nome);
        }

        [Test]
        public void ObterTodosOsContatosTest()
        {
            // Monta
            Contato contato1 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Alan"
            };
            Contato contato2 = new Contato()
            {
                Id = Guid.NewGuid(),
                Nome = "Wesley"
            };

            // Executa
            _contatos.Adicionar(contato1);
            _contatos.Adicionar(contato2);
            var listContatos = _contatos.ObterTodos();
            var umContato = listContatos.Where(c => c.Id == contato1.Id).FirstOrDefault();

            // Verifica
            Assert.IsTrue(listContatos.Count() > 1);
            Assert.AreEqual(umContato.Id, contato1.Id);
            Assert.AreEqual(umContato.Nome, contato1.Nome);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
