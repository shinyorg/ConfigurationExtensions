using Microsoft.Extensions.Configuration;

namespace SampleMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var config = new ConfigurationBuilder()
                .AddJsonPlatformBundle("appsettings.json", false)
                .AddPlatformPreferences()
                .AddSqlite()
                .Build();

            var builder = MauiApp.CreateBuilder();

            builder.Services.AddSingleton(config);
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<EntryPage>();
            builder.Services.AddTransient<EntryViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}