using System;

namespace GenericADSPack.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}

