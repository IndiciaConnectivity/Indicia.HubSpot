﻿# Indicia.HubSpot

[![NuGet](https://img.shields.io/nuget/v/Indicia.HubSpot.svg)](https://www.nuget.org/packages/Indicia.HubSpot/)
![publish nuget](https://github.com/IndiciaConnectivity/Indicia.HubSpot/workflows/publish%20nuget/badge.svg)

This package is heavily based on [HubSpot.NET](https://github.com/hubspot-net/HubSpot.NET), for which I really
would like to thank David Clarke and Turner Bass for their great work on that package.

The main differences are:

- We consume **v3** of the HubSpot API. This version is currently in developer preview, but
  is better than the v2 version in a lot of ways. It is a lot more consistent than v2.
- All methods are implemented **async**.
- We heavily use of some of the .NET Core (or `Microsoft.Extensions.*` packages for .NET Framework)
  dependency injection (DI), logging and configuration patterns. 

Currently, the only APIs which are supported are:

- Company
- Contact
- Deal
- Ticket

However, this could very easily be extended with the other object API's (Line Item, Product, Quote).

## TO DO

The Indicia.HubSpot client still needs a lot of work. Things that immediately pop into mind:

- OAuth support
- Support for the other object API types (Line Item, Product, Quote)
- Support for the non-object API types (Properties, Pipelines, Engagements, ...)
- Tests
- Support for non-string property types for the object models
- Support for auto-discovery of objectapi's using assembly scanning
- AsyncEnumerable support
- Add description xmldoc to object properties


## Getting started

To get started, install the [NuGet package](https://www.nuget.org/packages/Indicia.HubSpot/).

After installation, you need to register the package's classes in your service provider, something like
this:

```csharp
services.AddHubSpot(options =>
{
    options.Auth = new HubSpotApiKeyClientAuth("YOUR-API-KEY");
    options.UseHttpLogging = true; // Enabling this logs the HubSpot API requests and responses using Microsoft's ILogger
});
```
This allows you to inject the main entry points of this library, with `IHubSpotApi` as the most important one.

As an alternative for specifying the `Auth` using the `options`, you could also create and register your own
`IHubSpotClientAuthFactory`, which will take precedence when registered. Like this:

```csharp
// add services
services.AddTransient<IHubSpotClientAuthFactory, SomeHubSpotClientAuthFactory>();
services.AddHubSpot(options =>
{
    options.UseHttpLogging = true;
});
```

Together with something like this:

```csharp
public class SomeHubSpotClientAuthFactory : IHubSpotClientAuthFactory
{
    public Task<IHubSpotClientAuth> CreateAsync(CancellationToken cancellationToken = default)
    {
        var auth = new HubSpotApiKeyClientAuth("my API KEY");
        return Task.FromResult((IHubSpotClientAuth)auth);
    }
}
```


### Using your own models

As HubSpot lets you create and add custom properties to your contacts, companies and deals it's likely you'll want
to implement your own models. This is straightforward, simply extend the models shipped with this library,
e.g. `ContactHubSpotModel` and add your own properties. Use the `DataMember` attributes to indicate the internal name.
For example:

```csharp
public class HubSpotContact : HubSpotContactObject
{
    [DataMember(Name = "last_login")]
    public string LastLogin { get; set; }
}
```

Then, you have to register your own model and the corresponding `HubSpotObjectApi`, like this: 

```csharp
services.RegisterHubSpotObjectApi<HubSpotContact, HubSpotContactApi<HubSpotContact>>();
```

Wired together, you can use it like this:

```csharp
public class HubSpotTestCommand
{
    private readonly IHubSpotApi _hubSpotApi;

    public HubSpotTestCommand(IHubSpotApi hubSpotApi)
    {
        _hubSpotApi = hubSpotApi;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var contactApi = _hubSpotApi.GetObjectApi<HubSpotContact>();

        var result = await contactApi.BatchReadAsync(new List<string> {"email@example.com"}, new BatchReadParameters { Properties = contactApi.AllProperties, IdProperty = "email" },
            cancellationToken: cancellationToken);

        // Add your own logic here...
    }
}
```

### Use your own _IRestClient_

It is possible to register your own `IRestClient` implementation instead of the default one from RestSharp. For example, this allows extending
the `RestClient` class with retry policies using Polly. Just register your own implementation before calling `services.AddHubSpot(...)`:

```csharp
services.AddSingleton<IRestClient, MyAwesomeRestClient>();
services.AddHubSpot(options =>
{
    options.Auth = new HubSpotApiKeyClientAuth("YOUR-API-KEY");
});
```

## Contributing

Please read [CONTRIBUTING.md](https://github.com/IndiciaConnectivity/Indicia.HubSpot/blob/master/CONTRIBUTING.md) for more information on how to contribute. PRs welcome!


## Authors

- Jesse Klaasse
- Lesley Vente


## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/IndiciaConnectivity/Indicia.HubSpot/blob/master/LICENSE) file for details.


