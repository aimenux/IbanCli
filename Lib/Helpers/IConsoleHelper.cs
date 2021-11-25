namespace Lib.Helpers;

public interface IConsoleHelper
{
    void RenderTitle(string text);

    void RenderIban(string iban, string countryCode);

    void RenderIban(string iban, bool isValid);

    void RenderSettingsFile(string filepath);

    void RenderException(Exception exception);
}