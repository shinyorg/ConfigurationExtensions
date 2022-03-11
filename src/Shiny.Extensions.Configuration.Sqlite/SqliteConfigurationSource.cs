using Microsoft.Extensions.Configuration;


namespace Shiny.Extensions.Configuration.Sqlite
{
    public class SqliteConfigurationSource : IConfigurationSource
    {
        readonly string? connectionString;
        public SqliteConfigurationSource(string? connectionString) => this.connectionString = connectionString;

        public IConfigurationProvider Build(IConfigurationBuilder builder)
            => new SqliteConfigurationProvider(this.connectionString ?? "Data Source=Configuration.db");
    }
}
