# Moonad.Pipe

A simple F#'s pipe-forward operator port for C#. This lib is part of the [Moonad](https://moonad.net) project.

![Version](https://img.shields.io/nuget/v/moonad.pipe?label=version&color=029632) ![Tests](https://img.shields.io/github/actions/workflow/status/moonad-dotnet/moonad.pipe/main.yml?logo=github&label=tests&color=029632) ![Nuget](https://img.shields.io/nuget/dt/moonad.pipe?logo=nuget&label=downloads&color=029632)

## Installing
The project's package can be found on [Nuget](https://nuget.org/packages/moonad.pipe) and installed by your IDE or shell as following:

```shell
dotnet add package Moonad.Pipe
```

or

```shell
PM> Install-Package Moonad.Pipe
```

### Pipe-forward

The pipe-forward operator offers a way to chain methods passing the result of the prior to the next as the first parameter.

Example 1 - Sync pipe-forward:
```c#
10.Pipe(i => i + 10)
  .Pipe(i => $"Total: {i}")
  .Pipe(s => Console.WriteLine(s));
```

Example 2 - Async pipe-forward:
```c#
10.Pipe(i => i + 10)
  .Pipe(async i => await Task.FromResult($"Total: {i}"))
  .Pipe(s => Console.WriteLine(s));
```
