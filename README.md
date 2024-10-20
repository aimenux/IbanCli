[![.NET](https://github.com/aimenux/IbanCli/actions/workflows/ci.yml/badge.svg)](https://github.com/aimenux/IbanCli/actions/workflows/ci.yml)
[![NuGet](https://img.shields.io/nuget/v/IbanCli)](https://www.nuget.org/packages/IbanCli/)

# IbanCli
```
Providing a global tool in order to validate and generate ibans
```

> In this repo, i m building a global tool that allows to validate and generate ibans.
>
> The tool is based on two sub commands :
> - Use sub command `Generate` to generate an iban
> - Use sub command `Validate` to validate an iban
>
>
> To run code in debug or release mode, type the following commands in your favorite terminal : 
> - `.\App.exe Generate BE`
> - `.\App.exe Validate BE88630745557701`
>
>
> To install global tool from a local source path, type commands :
> - `dotnet tool install -g --configfile .\nugets\local.config IbanCli --version "*-*" --ignore-failed-sources`
>
> To install global tool from [nuget source](https://www.nuget.org/packages/IbanCli), type commands :
> - For stable version : `dotnet tool install -g IbanCli --ignore-failed-sources`
> - For prerelease version : `dotnet tool install -g IbanCli --version "*-*" --ignore-failed-sources`
>
> To run global tool, type commands :
> - `IbanCli -h`
> - `IbanCli Generate BE`
> - `IbanCli Validate BE88630745557701`
>
> ![IbanCli](Screenshots/IbanCli.png)
>

**`Tools`** : net 8.0, iban-net, command-line, spectre-console