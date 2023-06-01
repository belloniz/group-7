using System;
namespace GenericADSPack.Messaging
{
    public abstract class DomainEvent : Event
    {
        protected DomainEvent(int aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}

