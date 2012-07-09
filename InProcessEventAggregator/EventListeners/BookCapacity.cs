using InProcessEventAggregator.Domain.AggregateRoots;
using InProcessEventAggregator.Events;

namespace InProcessEventAggregator.EventListeners
{
    public class BookCapacity : IListenTo<SubscriptionCreated>, IListenTo<DeliverySizeChanged>
    {
        private readonly ISession _session;

        public BookCapacity(ISession session)
        {
            _session = session;
        }

        public void Notify(SubscriptionCreated evt)
        {
            var aggregateRoot = new Booking();
            // Do stuff
            _session.Save(aggregateRoot);
        }

        public void Notify(DeliverySizeChanged evt)
        {
            var aggregateRoot = new Booking();
            // Do stuff
            _session.Save(aggregateRoot);
        }
    }
}