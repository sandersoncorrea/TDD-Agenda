using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string id = Guid.NewGuid().ToString();
            string nome = "Diogo";

            // Executa
            _contatos.Adicionar(id, nome);

            // Verifica
            Assert.True(true);

        }

        [Test]
        public void ObterContatoTest()
        {
            // Monta
            string id = Guid.NewGuid().ToString();
            string nome = "Alex";

            // Executa
            _contatos.Adicionar(id, nome);
            var nomeResult = _contatos.Obter(id);

            // Verifica
            Assert.AreEqual(nome, nomeResult);
        }

        [TearDown]
        public void TearDown()
        {
            _contatos = null;
        }
    }
}
