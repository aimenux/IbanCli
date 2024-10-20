using System.ComponentModel.DataAnnotations;
using App.Services.Console;
using App.Services.Iban;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands;

[Command(Name = "Generate", FullName = "Generate IBAN", Description = "Generate IBAN.")]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
[HelpOption]
public class GenerateCommand : AbstractCommand
{
    private readonly IIbanService _ibanService;

    public GenerateCommand(IIbanService ibanService, IConsoleService consoleService) : base(consoleService)
    {
        _ibanService = ibanService;
    }

    [Required]
    [Argument(0, "CountryCode", "Iban CountryCode")]
    public string? CountryCode { get; init; }

    protected override void Execute(CommandLineApplication app)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(CountryCode);
        var iban = _ibanService.Generate(CountryCode);
        ConsoleService.RenderIban(iban, CountryCode);
    }

    protected override bool HasValidArguments()
    {
        return !string.IsNullOrWhiteSpace(CountryCode);
    }

    protected static string GetVersion() => GetVersion(typeof(GenerateCommand));
}