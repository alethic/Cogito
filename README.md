# Cogito

[![Build](https://github.com/alethic/Cogito/actions/workflows/Cogito.yml/badge.svg)](https://github.com/alethic/Cogito/actions/workflows/Cogito.yml)

Base utilities for .NET — the extension methods, small types and helpers the rest of the Cogito family is built on, plus Web Forms and Razor support for .NET Framework.

## Packages

**[Cogito.Core](https://www.nuget.org/packages/Cogito.Core)** — The base utility library the rest of the Cogito family is built on: extension methods and small types that fill gaps in the BCL.

**[Cogito.IO](https://www.nuget.org/packages/Cogito.IO)** — Typed filesystem paths, so the difference between a file and a directory — and between an absolute and a relative path — is visible in the type system.

**[Cogito.Irony](https://www.nuget.org/packages/Cogito.Irony)** — Helpers for working with parse trees produced by [Irony](https://github.com/IronyProject/Irony).

**[Cogito.Memory](https://www.nuget.org/packages/Cogito.Memory)** — Bit and span helpers for `Span<byte>` and `ReadOnlySpan<byte>`.

**[Cogito.Web.Http](https://www.nuget.org/packages/Cogito.Web.Http)** — Bind ASP.NET Web API action parameters to HTTP headers.

**[Cogito.Web.Razor](https://www.nuget.org/packages/Cogito.Web.Razor)** — Compile and run Razor templates outside ASP.NET.

**[Cogito.Web.UI](https://www.nuget.org/packages/Cogito.Web.UI)** — Extension methods for the ASP.NET Web Forms control tree.

**[Cogito.Web.UI.Razor](https://www.nuget.org/packages/Cogito.Web.UI.Razor)** — Render Razor templates from inside ASP.NET Web Forms.

Each package carries its own README with the detail; the links above go to nuget.org.

## Building

```shell
dotnet restore Cogito.slnx
dotnet msbuild -p:Configuration=Release Cogito.dist.msbuildproj
```

Packages are staged into `dist/nuget` and test suites into `dist/tests`; run a suite with
`dotnet test -f <tfm> <path to its assembly>`.

## License

MIT — see [LICENSE](LICENSE).
