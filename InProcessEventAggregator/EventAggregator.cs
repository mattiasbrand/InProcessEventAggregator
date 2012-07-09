using InProcessEventAggregator.EventListeners;
using InProcessEventAggregator.Events;
using StructureMap;

namespace InProcessEventAggregator
{
    public class EventAggregator : IEventAggregator
    {
        private readonly IContainer _container;

        public EventAggregator(IContainer container)
        {
            _container = container;
        }

        public void Publish<T>(T evt) where T:Event
        {
            var type = typeof (IListenTo<>);
            var fullType = type.MakeGenericType(evt.GetType());
            var listeners = _container.GetAllInstances(fullType);
            foreach (IListenTo<T> listener in listeners)
            {
                listener.Notify(evt);
            }
        }
    }
}