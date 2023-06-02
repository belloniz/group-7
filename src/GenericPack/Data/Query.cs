using System.Data;

namespace GenericPack.Data
{
    public abstract class Query: IDisposable
    {
        public readonly IDbConnection Connection;
        public String StringConnection { get; private set; }

        public Query(IDbConnection dbConnection)
        {            
            Connection =  dbConnection;
        }

        public void SetConnectionString(string connectionString)
        {
            StringConnection = connectionString;
            Connection.ConnectionString = connectionString; 
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}