using System;
namespace GenericPack.Messaging
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent(int aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}

