# Paperspace.net

[![Build Status](https://dev.azure.com/baristalabs/Paperspace/_apis/build/status/BaristaLabs.paperspace.net?branchName=master)](https://dev.azure.com/baristalabs/Paperspace/_build/latest?definitionId=12&branchName=master)
[![Coverage Status](https://img.shields.io/coveralls/github/BaristaLabs/paperspace.net/master.svg)](https://coveralls.io/github/BaristaLabs/paperspace.net?branch=master)
[![NuGet](http://img.shields.io/nuget/v/Paperspace.svg)](https://www.nuget.org/packages/Paperspace)

![logo](Paperspace.jpg)

Paperspace.net is a client library for .NET Standard 2.0 and above that provides an easy way to interact with the [Paperspace API](https://paperspace.github.io/paperspace-node/index.html).

With Paperspace.Net you can:

  - Create an application to start a new GPU-backed Windows VM based on a pre-built template and run a script on startup (Minutes)
  - Create an application to start a stopped GPU-backed Windows VM and run a PowerShell script on startup to perform an action, then shut it down. (Seconds)
  - Create a process that starts a Linux-based Docker container from a public or private docker registry, runs a command, and downloads the result (Seconds)
  - Create a queue-triggered Azure Function to perform web crawling activities that run in GPU-backed containers.
  - Create an Azure Durable Functions based orchestration that starts VMs based on incoming website requests and automatically streams the desktop to Azure Media Services.

# Usage examples

Get available machine templates.

```c#
var paperspace = new PaperspaceClient("<Paperspace API Key>");
var templates = await paperspace.Templates.List();
var w10template = templates.FirstOrDefault(t => t.OS == "Windows 10 (Server 2019) - Licensed");
Console.WriteLine(w10template.Label + " is available for creation!");
```

Create new virtual machine

``` c#
var newMachine = await client.Machines.Create(new CreateMachineRequest
{
    Region = Region.EastCoast_NY2,
    MachineType = MachineType.Air,
    Size = 50,
    BillingType = BillingType.Hourly,
    MachineName = "My Machine 1",
    TemplateId = w10template.Id,
    ScriptId: "s12345"
});
```

Create a new Script
``` c#
 var newScript = await client.Scripts.Create(new CreateScriptRequest
{
    ScriptName = "My Script",
    ScriptText = "echo Hello, World!",
    ScriptDescription = "A startup script",
    IsEnabled = true,
    RunOnce = false
});
```

Create a new job using jess/tetris:latest and wait until it completes

``` c#
var job = await client.Jobs.Create(new CreateJobRequest()
{
    Name = "Tetris",
    Container = "jess/tetris:latest",
    Command = "echo Hello, World! && echo 'Hello Paperspace!' > /artifacts/hello.txt",
    MachineType = MachineType.C2,
    Project = "Mah Tetris Project"
});
await client.Jobs.Waitfor(job.Id, JobState.Stopped, pollResultCallback: (j) => Console.WriteLine(j.State));
```

Other samples [available here](https://github.com/BaristaLabs/paperspace.net/tree/master/samples)

# ```Paperspace.Net``` -> ```Paperspace API``` Versioning

Paperspace.Net moves at a different cadence than the Paperspace API. The following table describes the version mapping.

| ```Paperspace.Net``` | ```PaperSpace API``` |
|:---:|:---:|
| 1.0.x | 0.1.17 |


# Development

This repository is a monorepo consisting of the following:

|   Path   | Description |
|---------:|:------------|
| /src/Paperspace | .Net Paperspace API Client |
| /src/Paperspace.PowerShell | Paperspace Powershell Cmdlets (Under development) |

Feel free to clone and code. Pull requests accepted!
