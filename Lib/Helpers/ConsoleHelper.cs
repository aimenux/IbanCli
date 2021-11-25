﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Spectre.Console;

namespace Lib.Helpers;

public class ConsoleHelper : IConsoleHelper
{
    public void RenderTitle(string text)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.Write(new FigletText(text).LeftAligned());
        AnsiConsole.WriteLine();
    }

    public void RenderIban(string iban, string countryCode)
    {
        var table = new Table()
            .BorderColor(Color.White)
            .Border(TableBorder.Square)
            .Title("[yellow]1 iban(s) generated[/]")
            .AddColumn(new TableColumn("[u]CountryCode[/]").Centered())
            .AddColumn(new TableColumn("[u]Iban[/]").Centered());

        table.AddRow(countryCode.ToUpper(), iban.ToUpper());

        AnsiConsole.WriteLine();
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }

    public void RenderIban(string iban, bool isValid)
    {
        var text = isValid
            ? $"[green]Iban {iban} is valid[/]"
            : $"[red]Iban {iban} is not valid[/]";

        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine(text);
        AnsiConsole.WriteLine();
    }

    public void RenderSettingsFile(string filepath)
    {
        var name = Path.GetFileName(filepath);
        var json = File.ReadAllText(filepath);
        var formattedJson = JToken.Parse(json).ToString(Formatting.Indented);
        var header = new Rule($"[yellow]({name})[/]");
        header.Centered();
        var footer = new Rule($"[yellow]({filepath})[/]");
        footer.Centered();

        AnsiConsole.WriteLine();
        AnsiConsole.Write(header);
        AnsiConsole.WriteLine(formattedJson);
        AnsiConsole.Write(footer);
        AnsiConsole.WriteLine();
    }

    public void RenderException(Exception exception)
    {
        const ExceptionFormats formats = ExceptionFormats.ShortenTypes
                                         | ExceptionFormats.ShortenPaths
                                         | ExceptionFormats.ShortenMethods;

        AnsiConsole.WriteLine();
        AnsiConsole.WriteException(exception, formats);
        AnsiConsole.WriteLine();
    }
}