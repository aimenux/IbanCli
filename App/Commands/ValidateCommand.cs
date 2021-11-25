using System.ComponentModel.DataAnnotations;
using Lib.Helpers;
using Lib.Services;
using McMaster.Extensions.CommandLineUtils;

namespace App.Commands
{
    [Command(Name = "Validate", FullName = "Validate IBAN", Description = "Validate IBAN.")]
    [VersionOptionFromMember(MemberName = nameof(GetVersion))]
    [HelpOption]
    public class ValidateCommand : AbstractCommand
    {
        private readonly IIbanService _ibanService;

        public ValidateCommand(IIbanService ibanService, IConsoleHelper consoleHelper) : base(consoleHelper)
        {
            _ibanService = ibanService;
        }

        [Required]
        [Argument(0, "Iban", "Iban to validate")]
        public string? Iban { get; set; }

        protected override void Execute(CommandLineApplication app)
        {
            ArgumentNullException.ThrowIfNull(Iban);
            var isValid = _ibanService.Validate(Iban);
            ConsoleHelper.RenderIban(Iban, isValid);
        }

        protected override bool HasValidArguments()
        {
            return !string.IsNullOrWhiteSpace(Iban);
        }

        protected static string GetVersion() => GetVersion(typeof(ValidateCommand));
    }
}
