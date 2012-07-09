using InProcessEventAggregator.EventListeners;
using InProcessEventAggregator.Events;
using StructureMap;

namespace InProcessEventAggregator
{
    public static class IoC
    {
        public static IContainer Container;

        static IoC()
        {
            Container = new Container(x=> 
            x.Scan(asm =>
                       {
                           asm.TheCallingAssembly();
                           asm.IncludeNamespaceContainingType<IListenTo<Event>>();
                           asm.ConnectImplementationsToTypesClosing(typeof (IListenTo<>));
                       }));
        }
    }
}