using InProcessEventAggregator.Events;

namespace InProcessEventAggregator
{
    public interface IEventAggregator
    {
        void Publish<T>(T evt) where T:Event;
    }
}