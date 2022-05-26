﻿using Microsoft.Extensions.Configuration;

namespace SampleMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var config = new ConfigurationBuilder()
                .AddJsonPlatformBundle("appsettings.json", false)
                .AddPlatformPreferences()
                .Build();

            var builder = MauiApp.CreateBuilder();

            builder.Configuration.AddConfiguration(config);
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<EntryPage>();
            builder.Services.AddTransient<EntryViewModel>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}