namespace Lib.Services;

public interface IIbanService
{
    bool Validate(string iban);

    string Generate(string countryCode);
}