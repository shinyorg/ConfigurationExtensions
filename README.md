# Xamarin Configuration for Microsoft.Extensions.Configuration

Why make this?  Can't I just use a standard csharp file or an embedded resource inside my shared project?
> You can, but if you are one of the devops culture that whitelabels, you likely just want to unpack/repack your IPAs and APKs.  By using Android assets and iOS bundles, you can have config
files that are changeable after packaging

Why have preference based providers if configuration is "readonly"?
> Well.... this is the thing.  It isn't as readonly now.  IConfiguration.Set now exists.  It means you can store all of your values in IConfiguration, change them, react to those changes with ReloadTokens, etc.  

Android Asset
* add appsettings.json to your android head project assets directory
* ensure file is androidasset


iOS Bundle
* add 