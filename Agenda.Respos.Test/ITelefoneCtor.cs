using Agenda.Domain;
using System;
using AutoFixture;
using Agenda.Respos.Test;

namespace Agenda.Repos.Test
{
    public class ITelefoneCtor : BaseCtor<ITelefone>
    {
        protected ITelefoneCtor() : base() {}
        public static ITelefoneCtor Um()
        {
            return new ITelefoneCtor();
        }

        public ITelefoneCtor Padrao()
        {
            _mock.SetupGet(o => o.Id).Returns(_fixture.Create<Guid>());
            _mock.SetupGet(o => o.Numero).Returns(_fixture.Create<string>());
            _mock.SetupGet(o => o.ContatoId).Returns(_fixture.Create<Guid>());
            return this;
        }

        public ITelefoneCtor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }

        public ITelefoneCtor ComNumero(string numero)
        {
            _mock.SetupGet(o => o.Numero).Returns(numero);
            return this;
        }

        public ITelefoneCtor ComContatoId(Guid contatoId)
        {
            _mock.SetupGet(o => o.ContatoId).Returns(contatoId);
            return this;
        }
    }
}
