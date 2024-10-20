using System.ComponentModel.DataAnnotations;
using App.Services.Console;
using App.Services.Iban;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands;

[Command(Name = "Validate", FullName = "Validate IBAN", Description = "Validate IBAN.")]
[VersionOptionFromMember(MemberName = nameof(GetVersion))]
[HelpOption]
public class ValidateCommand : AbstractCommand
{
    private readonly IIbanService _ibanService;

    public ValidateCommand(IIbanService ibanService, IConsoleService consoleService) : base(consoleService)
    {
        _ibanService = ibanService;
    }

    [Required]
    [Argument(0, "Iban", "Iban to validate")]
    public string? Iban { get; init; }

    protected override void Execute(CommandLineApplication app)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(Iban);
        var isValid = _ibanService.Validate(Iban);
        ConsoleService.RenderIban(Iban, isValid);
    }

    protected override bool HasValidArguments()
    {
        return !string.IsNullOrWhiteSpace(Iban);
    }

    protected static string GetVersion() => GetVersion(typeof(ValidateCommand));
}