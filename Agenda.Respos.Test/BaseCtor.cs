using Agenda.Domain;
using Moq;
using System;
using AutoFixture;

namespace Agenda.Respos.Test
{
    public class BaseCtor<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected BaseCtor()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return _mock.Object;
        }

        public Mock<T> Obter()
        {
            return _mock;
        }
    }


}
