using System.Reflection;
using Lib.Helpers;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands;

[Command(Name = "IbanCli", FullName = "Generate/Validate IBAN", Description = "Generate/Validate IBAN.")]
[Subcommand(typeof(GenerateCommand), typeof(ValidateCommand))]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
public class MainCommand : AbstractCommand
{
    public MainCommand(IConsoleHelper consoleHelper) : base(consoleHelper)
    {
    }

    [Option("-s|--settings", "Show settings information.", CommandOptionType.NoValue)]
    public bool ShowSettings { get; set; }

    protected override void Execute(CommandLineApplication app)
    {
        if (ShowSettings)
        {
            var filepath = GetSettingFilePath();
            ConsoleHelper.RenderSettingsFile(filepath);
        }
        else
        {
            const string title = "IbanCli";
            ConsoleHelper.RenderTitle(title);
            app.ShowHelp();
        }
    }

    protected static string GetVersion() => GetVersion(typeof(MainCommand));

    private static string GetSettingFilePath() => Path.GetFullPath(Path.Combine(GetDirectoryPath(), @"appsettings.json"));

    private static string GetDirectoryPath()
    {
        try
        {
            return Path.GetDirectoryName(GetAssemblyLocation())!;
        }
        catch
        {
            return Directory.GetCurrentDirectory();
        }
    }

    private static string GetAssemblyLocation() => Assembly.GetExecutingAssembly().Location;
}