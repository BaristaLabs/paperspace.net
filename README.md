# Paperspace.net

[![Build Status](https://dev.azure.com/baristalabs/Paperspace/_apis/build/status/Paperspace-.NET%20Core-CI?branchName=master)](https://dev.azure.com/baristalabs/Paperspace/_build/latest?definitionId=6&branchName=master)
[![Coverage Status](https://coveralls.io/repos/github/BaristaLabs/paperspace.net/badge.png?branch=master)](https://coveralls.io/github/BaristaLabs/paperspace.net?branch=master)
[![NuGet](http://img.shields.io/nuget/v/Paperspace.svg)](https://www.nuget.org/packages/Paperspace)

![logo](Paperspace.jpg)

Paperspace is a client library for .NET Standard 2.0 and above that provides an easy way to interact with the [Paperspace API](https://paperspace.github.io/paperspace-node/index.html).

## Usage examples

Get available templates.

```c#
var paperspace = new PaperspaceClient("<Paperspace API Key>");
var templates = await paperspace.Templates.List();
var w10template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2016) - Licensed");
Console.WriteLine(w10template.Label + " is available for creation!");
```

Other samples [available here](https://github.com/BaristaLabs/paperspace.net/tree/master/samples)
