namespace CRUDCORE.Business
{
    public class Connection
    {
        private string _connection = string.Empty;

        public Connection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _connection = builder.GetSection("ConnectionStrings:cnCrudCore").Value;
        }

        public string getConnectionSql()
        {
            return _connection;
        }
    }
}
