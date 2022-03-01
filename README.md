# Xamarin Configuration for Microsoft.Extensions.Configuration

## Nugets

|Release|NuGet|
|-------|-----|
|Stable|![Nuget](https://img.shields.io/nuget/v/shiny.extensions.configuration?style=for-the-badge)|
|Preview|![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/shiny.extensions.configuration?style=for-the-badge)|


## Builds

|Branch|Status|
|------|------|
|Master|[![Build](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml/badge.svg)](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml)|
|Dev|[![Build](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml/badge.svg?branch=dev)](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml)|
|Preview|[![Build](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml/badge.svg?branch=preview)](https://github.com/shinyorg/configurationextensions/actions/workflows/build.yml)|


## The Problem

Microsoft really did create a great set of abstractions for configuration.  You can store a set of key/values, cause a reload when a configuration source changes, & bind to strongly typed objects using Microsoft.Extensions.Configuration.Binder. On Mobile though, NONE of the current providers aren't really well.

Why?
* A big feature for IConfiguration, is the ability to trigger a reload of it's source without restarting the application.  Changing an appsettings.json file during runtime causes the IConfiguration to trigger a reload notification. 
* Mobile doesn't really have an appsettings.json.  Sure you could put this in an embedded resource, but than it is readonly at all times other than the build process... after that - it is locked in place
* Essentially, IConfiguration becomes a string based dictionary for all intents and purposes - pretty useless considering

## The Solution

How Shiny.Extensions.Configuration brings the power of IConfiguration to Mobile!
* A platform preferences configuration source which allows you to WRITE a value back using IConfiguration[key] = value;
* A whitelabellers dream - the ability to unpack, change a json config file, and repack without trigger a build by using proper platform directories to load up the JSON files while still having the power of a proper configuration library internally.

## Setup

#### AppSettings JSON

1. Create an appsettings.json file like you would in ASP.NET Core application in your HEAD project.
    * ANDROID: place the file in: Assets.  Ensure the build action on the file is set to 'AndroidAsset'
    * iOS: place the file in the ROOT of your project.  Ensure the build action on the file is set to 'BundleResource'
2. Configure your IConfiguration using the following code in your application startup code (ie. Xamarin.Forms App).

````csharp
// store this in your dependency injection container OR static class
var config = new ConfigurationBuilder()
    .AddJsonPlatformBundle() // NOTE: you can change the name of appsettings.json to something else and pass as an argument here
    .Build();
```

#### Preferences Provider

This provider allows writes and persists across application restarts.  It is a wrapper around the Android/iOS shared preferences.

For this configuration source, nothing special is required, simply add the following to the configuration builder.

```csharp
var configuration = new ConfigurationBuilder()
    .AddPlatformPreferences()
    .Build();
```

> NOTE: with the platform preferences provider, changes are supported.

```csharp
IConfiguration config = ...; // build
config["key"] = "value"; // write - this will cause a persist to the platform prefs and also trigger Option reloated events
```

## Links
* [Samples](https://github.com/shinyorg/ConfigurationExtensions/tree/master/Sample)
* [Microsoft Configuration Documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-6.0)
* [Microsoft Options Documentation](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0)
