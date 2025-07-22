using FluentValidation;
using RightWay.Application.Contract;
using RightWay.Application.Validator.Messages;

namespace RightWay.Application.Validator;

internal class AddressValidator
    : AbstractValidator<AddressContract>
{
    public AddressValidator()
    {
        RuleFor(c => c.ZipCode).NotEmpty().WithMessage(AddressMessage.ZipCodeNotEmpty)
            .MinimumLength(5).WithMessage(AddressMessage.ZipCodeMinimumSize)
            .MaximumLength(10).WithMessage(AddressMessage.ZipCodeMaximumSize);

        RuleFor(c => c.PublicPlace).NotEmpty().WithMessage(AddressMessage.PublicPlaceNotEmpty)
            .MinimumLength(5).WithMessage(AddressMessage.PublicPlaceMaximumSize);

        RuleFor(c => c.Neighborhood).NotEmpty().WithMessage(AddressMessage.NeighborhoodNotEmpty)
            .MinimumLength(5).WithMessage(AddressMessage.NeighborhoodMaximumSize);

        RuleFor(c => c.Locality).NotEmpty().WithMessage(AddressMessage.LocalityNotEmpty)
            .MinimumLength(5).WithMessage(AddressMessage.LocalityMaximumSize);

        RuleFor(c => c.State).NotEmpty().WithMessage(AddressMessage.StateNotEmpty)
            .MinimumLength(3).WithMessage(AddressMessage.StateMaximumSize);

        RuleFor(c => c.Region).NotEmpty().WithMessage(AddressMessage.RegionNotEmpty)
            .MinimumLength(3).WithMessage(AddressMessage.RegionMaximumSize);

        RuleFor(c => c.MunicipalCode).NotEmpty().WithMessage(AddressMessage.MunicipalCodeNotEmpty)
            .GreaterThanOrEqualTo(0).WithMessage(AddressMessage.NegativeMunicipalCode);

        RuleFor(c => c.Number).NotEmpty().WithMessage(AddressMessage.NumberNotEmpty)
            .GreaterThan(0).WithMessage(AddressMessage.NegativeNumber);
    }
}