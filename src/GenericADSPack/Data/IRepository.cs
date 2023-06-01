using GenericADSPack.Domain;
using System;

namespace GenericADSPack.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}