# Cogito.Irony

Helpers for working with parse trees produced by [Irony](https://github.com/IronyProject/Irony).

## Why

Irony hands you a `ParseTree` and leaves navigation to you, so grammar code fills up with index
arithmetic over child nodes. These extensions let you address nodes by term name and turn a tree into
XML, which makes a grammar far easier to debug.

## Install

```shell
dotnet add package Cogito.Irony
```

## Use

```csharp
var tree = parser.Parse(text);
tree.ThrowParseErrors();

var name = tree.Root.Node("identifier").SpanText();
foreach (var arg in tree.Root.Nodes("argument"))
    Handle(arg);
```

`ToXDocument` / `ToXElement` render a whole tree as XML — the quickest way to see what a grammar
actually matched. `ThrowParseErrors` turns Irony's error collection into a `ParseException`.

## License

MIT.
