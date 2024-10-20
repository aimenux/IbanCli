using App.Services.Console;
using McMaster.Extensions.CommandLineUtils;
using static App.Extensions.PathExtensions;

namespace App.Commands;

[Command(Name = "IbanCli", FullName = "Generate/Validate IBAN", Description = "Generate/Validate IBAN.")]
[Subcommand(typeof(GenerateCommand), typeof(ValidateCommand))]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
public class MainCommand : AbstractCommand
{
    public MainCommand(IConsoleService consoleService) : base(consoleService)
    {
    }

    [Option("-s|--settings", "Show settings information.", CommandOptionType.NoValue)]
    public bool ShowSettings { get; init; }

    protected override void Execute(CommandLineApplication app)
    {
        if (ShowSettings)
        {
            var filepath = GetSettingFilePath();
            ConsoleService.RenderSettingsFile(filepath);
        }
        else
        {
            const string title = "IbanCli";
            ConsoleService.RenderTitle(title);
            app.ShowHelp();
        }
    }

    protected static string GetVersion() => GetVersion(typeof(MainCommand));
}