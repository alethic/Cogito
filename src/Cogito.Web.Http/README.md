# Cogito.Web.Http

Bind ASP.NET Web API action parameters to HTTP headers.

## Why

Web API binds from the route, query string and body out of the box, but not from headers — so header
values get read out of `Request.Headers` inside the action, which keeps them out of the method
signature and out of model validation.

## Install

```shell
dotnet add package Cogito.Web.Http
```

## Use

```csharp
public IHttpActionResult Get([FromHeader("X-Correlation-Id")] string correlationId)
{
    ...
}
```

`FromHeaderAttribute` supplies the value provider; `HeaderValueProviderFactory` is registered for you
and can be replaced through `IHeaderValueProviderFactory`.

Targets .NET Framework.

## License

MIT.
