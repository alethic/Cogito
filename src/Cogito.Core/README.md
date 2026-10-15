# Cogito.Core

The base utility library the rest of the Cogito family is built on: extension methods and small types
that fill gaps in the BCL.

## Why

Every codebase accumulates the same handful of helpers — a null-safe `EmptyIfNull`, an async lock, a
dictionary that creates missing entries, reflection helpers that walk property paths. This is that
set, written once and shared, rather than copied into each project.

## Install

```shell
dotnet add package Cogito.Core
```

## What's in it

**LINQ and collections** — `EmptyIfNull`, `Expand`, `AnyAsync` / `AllAsync`,
`Combinatorials`, `DemandDictionary` (a dictionary that produces a value on first access).

**Async** — `AsyncLock` and `AsyncManualResetEvent`, for coordination in code that cannot block.

**Reflection** — `GetPropertyOrField`, `GetPropertyOrFieldFromPath`, `GetAssignableTypes`,
`GetTargetMemberInfo`, and assembly-name helpers.

**Text and bytes** — byte-array helpers, media-type resolution.

**.NET Framework only** — members .NET has and .NET Framework lacks, named and shaped as in .NET and
placed in the matching `Cogito` namespace: `Cogito.Numerics.BitOperations.LeadingZeroCount` and
`Cogito.Collections.Generic.CollectionExtensions.GetValueOrDefault`. Import both, for example
`System.Numerics` and `Cogito.Numerics`, and the same call compiles on both: on .NET it binds to the
built-in member. For other APIs .NET has and .NET Framework lacks, use
[Polyfill](https://github.com/SimonCropp/Polyfill).

**Files** — `DelayedFileSystemWatcher`, which coalesces the burst of events the framework watcher
raises for a single logical change.

`Cogito.Linq` is the namespace most consumers want; it is in this package.

## License

MIT.
