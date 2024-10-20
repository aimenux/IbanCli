using App.Services.Iban;
using FluentAssertions;
using IbanNet;
using IbanNet.Registry;
using Xunit;

namespace Tests;

public class IbanServiceTests
{
    [Theory]
    [InlineData("BE71096123456769")]
    [InlineData("FI1410093000123458")]
    [InlineData("BE71 0961 2345 6769")]
    [InlineData("DE75512108001245126199")]
    [InlineData("TN5904018104004942712345")]
    [InlineData("CZ5508000000001234567899")]
    [InlineData("ES7921000813610123456789")]
    [InlineData("PT50002700000001234567833")]
    [InlineData("FR1420041010050500013M02606")]
    [InlineData("DE91 1000 0000 0123 4567 89")]
    [InlineData("KW81CBKU0000000000001234560101")]
    [InlineData("FR76 3000 6000 0112 3456 7890 189")]
    [InlineData("BR15 0000 0000 0000 1093 2840 814 P2")]
    public void Should_Be_Valid_Iban(string iban)
    {
        // arrange
        var service = new IbanService(new IbanValidator(), new IbanGenerator());

        // act
        var isValid = service.Validate(iban);

        // assert
        isValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("BE71096123456719")]
    [InlineData("FI1410093000123448")]
    [InlineData("BE71 0961 2345 6763")]
    [InlineData("DE75512108001245126192")]
    [InlineData("TN5904018104004942712341")]
    [InlineData("CZ5508000000001234567890")]
    [InlineData("ES7921000813610123456784")]
    [InlineData("PT50002700000001234567873")]
    [InlineData("FR1420041010050500013M02616")]
    [InlineData("DE91 1000 0000 0123 4567 39")]
    [InlineData("KW81CBKU0000000000001234560111")]
    [InlineData("FR76 3000 6000 0112 3456 7890 199")]
    [InlineData("BR15 0000 0000 0000 1093 2840 814 52")]
    public void Should_Not_Be_Valid_Iban(string iban)
    {
        // arrange
        var service = new IbanService(new IbanValidator(), new IbanGenerator());

        // act
        var isValid = service.Validate(iban);

        // assert
        isValid.Should().BeFalse();
    }

    [Theory]
    [InlineData("BE")]
    [InlineData("FR")]
    [InlineData("DE")]
    [InlineData("ES")]
    [InlineData("PT")]
    [InlineData("IT")]
    [InlineData("TN")]
    public void Should_Generate_Valid_Iban(string countryCode)
    {
        // arrange
        var service = new IbanService(new IbanValidator(), new IbanGenerator());

        // act
        var iban = service.Generate(countryCode);

        // assert
        iban.Should().NotBeNullOrWhiteSpace();
        service.Validate(iban).Should().BeTrue();
    }
}