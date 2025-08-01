using FluentAssertions;
using RightWay.Application.Contract;
using RightWay.Application.Validator;
using RightWay.Domain.Enum;

namespace RightWay.Application.Tests.Validator;

public class OrderContractValidatorTests
{
    private readonly OrderValidator _validator = new();

    [Fact]
    public void Should_Be_Successful_When_The_Request_Is_Filled_Out_Correctly()
    {
        var request = new OrderContract(0.2f, 1.20f, PriorityLevelEnum.NORMAL, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null });
        var result = _validator.Validate(request);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(51)]
    public void Should_Fail_Weight_Is_Filled_Incorrect(float weight)
    {
        var request = new OrderContract(weight, 2.10f, PriorityLevelEnum.LOW, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null });
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Weight" &&
            err.ErrorMessage == "Weight greater than permitted");
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1.51)]
    [InlineData(2.0)]
    [InlineData(2.5)]
    public void Should_Fail_Height_Is_Filled_Incorrect(float height)
    {
        var request = new OrderContract(0.2f, height, PriorityLevelEnum.LOW, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null });
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Height" &&
            err.ErrorMessage == "Height greater than permitted");
    }

    [Theory]
    [InlineData(3)]
    [InlineData(10)]
    [InlineData(44)]
    public void Should_Fail_When_The_PriorityLevel_Is_Filled_Incorrectly(int priorityLevel)
    {
        var request = new OrderContract(0.2f, 1.20f, (PriorityLevelEnum)priorityLevel, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null });
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "PriorityLevel" &&
            err.ErrorMessage == "The 'Priority Level' must be filled with the worst of the request. 0 = Low | 1 = Normal | 2 = Urgent");
    }

    [Fact]
    public void Should_Fail_When_Address_Is_Not_Populated()
    {
        var request = new OrderContract(0.2f, 1.20f, PriorityLevelEnum.URGENT, null!);
        var result = _validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().NotBeNullOrEmpty();
        result.Errors.Should().ContainSingle(err =>
            err.PropertyName == "Address" &&
            err.ErrorMessage == "The 'Address' must be filled");
    }
}