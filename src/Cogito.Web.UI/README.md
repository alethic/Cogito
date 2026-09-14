# Cogito.Web.UI

Extension methods for the ASP.NET Web Forms control tree.

## Why

Web Forms gives you a control hierarchy and almost no way to query it. Finding every control of a
type, or the nearest ancestor that implements an interface, means writing the same recursive walk
again in every project.

## Install

```shell
dotnet add package Cogito.Web.UI
```

## Use

```csharp
foreach (var box in Page.Traverse().OfType<TextBox>())
    box.Enabled = false;
```

`Traverse` walks the tree depth-first so you can use LINQ against it. `ControlExtensions`,
`ControlCollectionExtensions`, `WebControlExtensions` and `HtmlControlExtensions` cover the rest;
`CogitoControl` is a base class for controls that want them.

Targets .NET Framework — Web Forms only exists there.

## License

MIT.
