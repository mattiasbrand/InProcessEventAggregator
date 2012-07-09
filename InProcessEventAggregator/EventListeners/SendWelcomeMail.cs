using InProcessEventAggregator.Domain.AggregateRoots;
using InProcessEventAggregator.Events;

namespace InProcessEventAggregator.EventListeners
{
    public class SendWelcomeMail : IListenTo<SubscriptionCreated>
    {
        private readonly ISession _session;

        public SendWelcomeMail(ISession session)
        {
            _session = session;
        }

        public void Notify(SubscriptionCreated evt)
        {
            var aggregateRoot = new Mail();
            // Send mail
            _session.Save(aggregateRoot);
        }
    }
}