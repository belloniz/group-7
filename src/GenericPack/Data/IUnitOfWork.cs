namespace GenericPack.Data
{
	public interface IUnitOfWork
	{
		Task<bool> Commit();
	}
}

