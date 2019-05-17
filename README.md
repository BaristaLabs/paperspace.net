# Paperspace.net

[![NuGet](http://img.shields.io/nuget/v/Paperspace.svg)](https://www.nuget.org/packages/Paperspace)

![logo](Paperspace.jpg)

Paperspace is a client library for .NET Standard 2.0 and above that provides an easy way to interact with the [Paperspace API](https://paperspace.github.io/paperspace-node/index.html).

## Usage examples

Get available templates.

```c#
var paperspace = new PaperspaceClient("<Paperspace API Key>");
var templates = await github.Templates.List();
var w10template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2016) - Licensed");
Console.WriteLine(w10template.Label + " is available for creation!");
```

Other samples [available here](https://github.com/BaristaLabs/paperspace.net/tree/master/samples)