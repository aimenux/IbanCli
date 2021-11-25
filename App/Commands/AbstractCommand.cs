﻿using System.Reflection;
using Lib.Helpers;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands;

public abstract class AbstractCommand
{
    protected IConsoleHelper ConsoleHelper;

    protected AbstractCommand(IConsoleHelper consoleHelper)
    {
        ConsoleHelper = consoleHelper;
    }

    public void OnExecute(CommandLineApplication app)
    {
        try
        {
            if (!HasValidOptions() || !HasValidArguments())
            {
                throw new Exception($"Invalid options/arguments for command {GetType().Name}");
            }

            Execute(app);
        }
        catch (Exception ex)
        {
            ConsoleHelper.RenderException(ex);
        }
    }

    protected abstract void Execute(CommandLineApplication app);

    protected virtual bool HasValidOptions() => true;

    protected virtual bool HasValidArguments() => true;

    protected static string GetVersion(Type type)
    {
        return type
            .Assembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion!;
    }
}