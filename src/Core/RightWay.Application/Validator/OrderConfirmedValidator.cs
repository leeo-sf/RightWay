using FluentValidation;
using RightWay.Application.Request.Order;
using RightWay.Application.Validator.Messages;

namespace RightWay.Application.Validator;

public class OrderConfirmedValidator
    : AbstractValidator<OrderConfirmedRequest>
{
    public OrderConfirmedValidator()
    {
        RuleFor(c => c.Orders)
            .NotEmpty().WithMessage(OrderMessage.NotEmptyOrder)
            .Must(order => order.Count <= 100).WithMessage(OrderMessage.NumberOfOrdersAboveTheAllowed);

        RuleForEach(c => c.Orders)
            .SetValidator(new OrderValidator());
    }
}