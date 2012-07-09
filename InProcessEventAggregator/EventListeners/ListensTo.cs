using InProcessEventAggregator.Events;

namespace InProcessEventAggregator.EventListeners
{
    public interface IListenTo<T> where T:Event
    {
        void Notify(T evt);
    }
}