namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddSqlite(this IConfigurationBuilder builder, string? connectionString = null)
        {
            return builder;
        }
    }
}