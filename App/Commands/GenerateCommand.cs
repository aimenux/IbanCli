using System.ComponentModel.DataAnnotations;
using Lib.Helpers;
using Lib.Services;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands;

[Command(Name = "Generate", FullName = "Generate IBAN", Description = "Generate IBAN.")]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
[HelpOption]
public class GenerateCommand : AbstractCommand
{
    private readonly IIbanService _ibanService;

    public GenerateCommand(IIbanService ibanService, IConsoleHelper consoleHelper) : base(consoleHelper)
    {
        _ibanService = ibanService;
    }

    [Required]
    [Argument(0, "CountryCode", "Iban CountryCode")]
    public string? CountryCode { get; set; }

    protected override void Execute(CommandLineApplication app)
    {
        ArgumentNullException.ThrowIfNull(CountryCode);
        var iban = _ibanService.Generate(CountryCode);
        ConsoleHelper.RenderIban(iban, CountryCode);
    }

    protected override bool HasValidArguments()
    {
        return !string.IsNullOrWhiteSpace(CountryCode);
    }

    protected static string GetVersion() => GetVersion(typeof(GenerateCommand));
}