using ServiceStack.OrmLite;

namespace LibraryBusinessLogic.DBManagement
{
    public class DatabaseConfig
    {
        public string connectionstring = "SERVER=localhost;port=3306;DATABASE=librarysystem;Username=root;Password=PinalPambhar7401";

        public OrmLiteConnectionFactory GetConnection()
        {
            return new OrmLiteConnectionFactory(connectionstring, MySqlDialect.Provider);
        }
    }
}
