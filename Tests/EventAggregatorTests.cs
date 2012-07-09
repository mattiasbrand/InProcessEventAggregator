using System;
using System.Collections.Generic;
using System.Linq;
using InProcessEventAggregator;
using InProcessEventAggregator.Domain.AggregateRoots;
using InProcessEventAggregator.Events;
using NUnit.Framework;
using Rhino.Mocks;

namespace Tests
{
    [TestFixture]
    public class When_publishing_a_SubscriptionCreated_event
    {
        private ISession _session;
        private readonly List<object> _saved = new List<object>();

        [TestFixtureSetUp]
        public void Context()
        {
            _session = MockRepository.GenerateMock<ISession>();
            _session.Stub(x => x.Save(Arg<object>.Is.NotNull))
                .WhenCalled(x => _saved.Add(x.Arguments.First()));
            var container = IoC.Container;
            container.Configure(x => x.For<ISession>().Use(_session));
            var eventAggregator = new EventAggregator(container);

            eventAggregator.Publish(new SubscriptionCreated());
        }

        [Test]
        public void Should_book_capacity()
        {
            Assert.IsTrue(_saved.Any(o => o is Booking));
        }

        [Test]
        public void Should_send_welcome_mail()
        {
            Assert.IsTrue(_saved.Any(o => o is Mail));
        }

        [Test]
        public void Should_start_billing()
        {
            Assert.IsTrue(_saved.Any(o => o is Billing));
        }
    }
}