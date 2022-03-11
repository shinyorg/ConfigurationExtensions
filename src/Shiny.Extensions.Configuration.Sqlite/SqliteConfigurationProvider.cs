using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Shiny.Extensions.Configuration.Sqlite
{
    public class SqliteConfigurationProvider : ConfigurationProvider
    {
        readonly string connectionString;
        public SqliteConfigurationProvider(string connectionString)
            => this.connectionString = connectionString;


        public override void Load()
        {
            this.Execute("CREATE TABLE IF NOT EXISTS ConfigurationValues(Key TEXT PRIMARY KEY, Value TEXT)");
            this.ExecuteRead(
                reader => this.Data.Add(
                    reader.GetString(0), 
                    reader.GetString(1)
                ),
                "SELECT Key, Value FROM ConfigurationValues ORDER BY Key"
            );
            base.Load();
        }


        public override void Set(string key, string value)
        {
            this.Execute(
                "INSERT INTO ConfigurationValues(Key, Value) VALUES (@Key, @Value) ON CONFLICT(Key) DO UPDATE SET Value = @Value",
                new SqliteParameter("@Key", key),
                new SqliteParameter("@Value", value)
            );
            base.Set(key, value);
        }


        
        int Execute(string sql, params SqliteParameter[] parameters)
        {
            using (var conn = new SqliteConnection(this.connectionString))
            {
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        parameter.Value ??= DBNull.Value;
                        command.Parameters.Add(parameter);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }


        void ExecuteRead(Action<SqliteDataReader> onRead, string sql, params SqliteParameter[] parameters)
        {
            using (var conn = new SqliteConnection(this.connectionString))
            {
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        parameter.Value ??= DBNull.Value;
                        command.Parameters.Add(parameter);
                    }
                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read()) 
                            onRead(reader);
                    }
                }
            }
        }
    }
}
