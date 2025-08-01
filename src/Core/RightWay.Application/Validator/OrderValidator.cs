using FluentValidation;
using RightWay.Application.Contract;
using RightWay.Application.Validator.Messages;
using RightWay.Domain.Enum;

namespace RightWay.Application.Validator;

public class OrderValidator
    : AbstractValidator<OrderContract>
{
    public OrderValidator()
    {
        RuleFor(c => c.Weight).NotEmpty().WithMessage(OrderMessage.NotEmptyWeight)
            .InclusiveBetween(0.01f, 50f).WithMessage(OrderMessage.WeightGreatherThanPermitted);

        RuleFor(c => c.Height).NotEmpty().WithMessage(OrderMessage.NotEmptyHeight)
            .InclusiveBetween(0.01f, 1.50f).WithMessage(OrderMessage.HeightGreatherThanPermitted);

        RuleFor(c => c.PriorityLevel).NotEmpty().WithMessage(OrderMessage.NotEmptyPriorityLevel)
            .Must(status => Enum.IsDefined(typeof(PriorityLevelEnum), status)).WithMessage(OrderMessage.InvalidPriorityLevel);

        RuleFor(c => c.Address).NotNull().WithMessage(OrderMessage.AddressNotEmpty)
            .SetValidator(new AddressValidator());
    }
}