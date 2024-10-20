namespace App.Services.Iban;

public interface IIbanService
{
    bool Validate(string iban);

    string Generate(string countryCode);
}