# Cogito.Web.Razor

Compile and run Razor templates outside ASP.NET.

## Why

The Razor parser is useful well beyond MVC — generating email bodies, reports, or code — but hosting
it yourself means dealing with `RazorEngineHost`, code generation and compilation by hand. This wraps
that into a template you can build and execute.

## Install

```shell
dotnet add package Cogito.Web.Razor
```

## Use

```csharp
var template = new RazorTemplateBuilder()
    .Build("Hello, @Model.Name.");

var text = template.Run(new { Name = "World" });
```

`RazorHost` is the configured engine host, `IRazorTemplate` the compiled result. Compilation and
parse failures surface as `CompilerErrorException` and `ParserErrorException` rather than as an
error collection you have to inspect.

Targets .NET Framework.

## License

MIT.
