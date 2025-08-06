using FluentAssertions;
using RightWay.Application.Contract;
using RightWay.Domain.Enum;
using RightWay.Application.Validator;
using RightWay.Application.Tests.TestData;

namespace RightWay.Application.Tests.Validator;

public class AddressValidatorTests
{
    private readonly AddressValidator _validator = new();

    [Theory]
    [MemberData(nameof(AddressTestData.ValidAddresses), MemberType = typeof(AddressTestData))]
    public void Should_Be_Successful_When_The_Request_Is_Filled_Out_Correctly(AddressContract request)
    {
        var result = _validator.Validate(request);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData("")]
    [InlineData("0")]
    [InlineData("01")]
    [InlineData("010")]
    [InlineData("0100")]
    public void Should_Fail_When_The_ZipCode_Is_Filled_Smaller_Than_Allowed(string zipCode)
    {
        var request = new AddressContract { ZipCode = zipCode, PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "ZipCode" &&
            err.ErrorMessage == "The 'Zip Code' filled in is incorrect");
    }

    [Theory]
    [InlineData("01001000-1020")]
    [InlineData("01001000-1021")]
    [InlineData("01001000-10222")]
    public void Should_Fail_When_The_ZipCode_Is_Filled_Larger_Than_Allowed(string zipCode)
    {
        var request = new AddressContract { ZipCode = zipCode, PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "ZipCode" &&
            err.ErrorMessage == "The 'Zip Code' must be filled out correctly");
    }

    [Fact]
    public void Should_Fail_When_The_PublicPlace_Is_Empty()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "PublicPlace" &&
            err.ErrorMessage == "The 'Public Place' must be filled in");
    }

    [Fact]
    public void Should_Fail_When_The_PublicPlace_Is_Smaller_Than_Allowed()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "test", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "PublicPlace" &&
            err.ErrorMessage == "The 'Public Place' must be filled out correctly");
    }

    [Fact]
    public void Should_Fail_When_The_Neighborhood_Is_Empty()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Neighborhood" &&
            err.ErrorMessage == "The 'Neighborhood' must be filled in");
    }

    [Fact]
    public void Should_Fail_When_The_Neighborhood_Is_Smaller_Than_Allowed()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "S", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Neighborhood" &&
            err.ErrorMessage == "The 'Neighborhood' must be filled out correctly");
    }

    [Fact]
    public void Should_Fail_When_The_Locality_Is_Empty()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Locality" &&
            err.ErrorMessage == "The 'Locality' must be filled in");
    }

    [Fact]
    public void Should_Fail_When_The_Locality_Is_Smaller_Than_Allowed()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "Sp", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Locality" &&
            err.ErrorMessage == "The 'Locality' must be filled out correctly");
    }

    [Fact]
    public void Should_Fail_When_The_State_Is_Empty()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "State" &&
            err.ErrorMessage == "The 'State' must be filled in");
    }

    [Fact]
    public void Should_Fail_When_The_State_Is_Smaller_Than_Allowed()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "Sp", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "State" &&
            err.ErrorMessage == "The 'State' must be filled out correctly");
    }

    [Fact]
    public void Should_Fail_When_The_Region_Is_Empty()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Region" &&
            err.ErrorMessage == "The 'Region' must be filled in");
    }

    [Fact]
    public void Should_Fail_When_The_Region_Is_Smaller_Than_Allowed()
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Su", MunicipalCode = 3550308, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Region" &&
            err.ErrorMessage == "The 'Region' must be filled out correctly");
    }

    [Theory]
    [InlineData(-3550308)]
    [InlineData(-1)]
    public void Should_Fail_When_The_MunicipalCode_Is_Incorrect(int municipalCode)
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = municipalCode, Number = 10, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "MunicipalCode" &&
            err.ErrorMessage == "The 'Municipal Code' cannot be negative");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-12)]
    [InlineData(-1)]
    public void Should_Fail_When_The_Number_Is_Incorrect(int number)
    {
        var request = new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = number, Complement = null };
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Number" &&
            err.ErrorMessage == "The address number cannot be negative");
    }
}