using RightWay.Application.Dto;
using RightWay.Application.Extension;
using RightWay.Domain.Enum;

namespace RightWay.Application.Tests.TestData.Request;

internal static class OrderAwaitingSeparationRequestTestsData
{
    private static readonly Random random = new Random();

    public static List<OrderDto> OrdersDto()
    {
        var addressId = Guid.NewGuid();
        return new List<OrderDto>
        {
            new(Guid.NewGuid(), (float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.NORMAL.GetDescription(), OrderStatusEnum.FAILED.GetDescription(), new(addressId, "06492-000", "Praça da Sé", "Sé", "São Paulo", StateEnum.SP.GetDescription(), "São Paulo", "Sudeste", 3550308, 12, null)),
        };
    }
}