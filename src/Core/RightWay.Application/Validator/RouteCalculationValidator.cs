using FluentValidation;
using RightWay.Application.Request;

namespace RightWay.Application.Validator;

public class RouteCalculationValidator
    : AbstractValidator<RouteCalculationRequest>
{
    public RouteCalculationValidator()
    {
        RuleForEach(c => c.Addresses)
            .SetValidator(new AddressValidator());
    }
}