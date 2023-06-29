using GenericPack.Messaging;

namespace GenericPack.Domain
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
