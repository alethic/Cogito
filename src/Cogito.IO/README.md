# Cogito.IO

Typed filesystem paths, so the difference between a file and a directory — and between an absolute
and a relative path — is visible in the type system.

## Why

Paths passed around as `string` lose every distinction that matters. Nothing stops you combining two
absolute paths, or handing a directory where a file was wanted; you find out at runtime. These types
make those mistakes not compile.

## Install

```shell
dotnet add package Cogito.IO
```

## Use

```csharp
var root = new DirectoryPathAbsolute(@"C:\data");
var file = root.Combine(new FilePathRelative(@"reports\march.csv"));
```

`FilePath` and `DirectoryPath` each come in absolute and relative forms, and combination is only
defined where it makes sense. `PathHelper` and `PathMode` cover normalisation and comparison.

## License

MIT.
