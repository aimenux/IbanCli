using IbanNet;
using IbanNet.Registry;

namespace Lib.Services;

public class IbanService : IIbanService
{
    private readonly IIbanValidator _validator;
    private readonly IIbanGenerator _generator;

    public IbanService(IIbanValidator validator, IIbanGenerator generator)
    {
        _validator = validator;
        _generator = generator;
    }

    public bool Validate(string iban)
    {
        return _validator.Validate(iban).IsValid;
    }

    public string Generate(string countryCode)
    {
        var iban = _generator.Generate(countryCode);
        return iban.ToString();
    }
}