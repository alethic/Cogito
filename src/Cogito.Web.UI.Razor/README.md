# Cogito.Web.UI.Razor

Render Razor templates from inside ASP.NET Web Forms.

## Why

Web Forms markup is painful for anything list-shaped, and a whole-application move to MVC is rarely
on the table. This lets you write the awkward parts as Razor and drop them into an existing page or
user control, one template at a time.

## Install

```shell
dotnet add package Cogito.Web.UI.Razor
```

## Use

```csharp
public partial class ProductList : RazorControl
{
}
```

`RazorControl` and `RazorControlTemplate` render a template as part of the normal control lifecycle,
so the output participates in the page as any other control would. `RazorPage` does the same at page
level, and `HtmlHelperResult` carries pre-encoded markup.

Targets .NET Framework. Built on `Cogito.Web.Razor`.

## License

MIT.
