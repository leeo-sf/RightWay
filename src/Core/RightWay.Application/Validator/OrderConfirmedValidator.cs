using FluentValidation;
using RightWay.Application.Request;
using RightWay.Application.Validator.Messages;

namespace RightWay.Application.Validator;

public class OrderConfirmedValidator
    : AbstractValidator<OrderConfirmedRequest>
{
    public OrderConfirmedValidator()
    {
        RuleFor(c => c.Orders)
            .NotEmpty().WithMessage(OrderMessage.NotEmptyOrder);

        RuleForEach(c => c.Orders)
            .SetValidator(new OrderValidator());
    }
}