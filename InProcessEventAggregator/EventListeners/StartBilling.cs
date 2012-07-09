using InProcessEventAggregator.Domain.AggregateRoots;
using InProcessEventAggregator.Events;

namespace InProcessEventAggregator.EventListeners
{
    public class StartBilling : IListenTo<SubscriptionCreated>
    {
        private readonly ISession _session;

        public StartBilling(ISession session)
        {
            _session = session;
        }

        public void Notify(SubscriptionCreated evt)
        {
            var aggregateRoot = new Billing();
            // Do stuff
            _session.Save(aggregateRoot);
        }
    }
}