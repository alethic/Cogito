# Cogito.Memory

Bit and span helpers for `Span<byte>` and `ReadOnlySpan<byte>`.

## Why

Working with bitfields over spans means writing the same masking and shifting each time, and getting
it subtly wrong at the byte boundary. These are the operations, tested.

## Install

```shell
dotnet add package Cogito.Memory
```

## Use

```csharp
Span<byte> flags = stackalloc byte[4];

flags.SetBit(13, true);
var set = flags.GetBit(13);

var leading = flags.CountLeadingZeros();
var hex = flags.ToHexString();
```

Bitwise `And`, `AndNot`, `Or` and `Xor` operate span-to-span in place.

## License

MIT.
