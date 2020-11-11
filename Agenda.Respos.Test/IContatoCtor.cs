using System;
using Agenda.Domain;

namespace Agenda.Respos.Test
{
    public class IContatoCtor : BaseCtor<IContato>
    {
        protected IContatoCtor() : base() { }
        public static IContatoCtor Um()
        {
            return new IContatoCtor();
        }

        public IContatoCtor ComNome(string nome)
        {
            _mock.SetupGet(o => o.Nome).Returns(nome);
            return this;
        }

        public IContatoCtor ComId(Guid id)
        {
            _mock.SetupGet(o => o.Id).Returns(id);
            return this;
        }
    }
}
