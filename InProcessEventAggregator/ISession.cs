namespace InProcessEventAggregator
{
    public interface ISession
    {
        void Save(object toSave);
    }
}