using RightWay.Application.Contract;
using RightWay.Domain.Enum;

namespace RightWay.Api.Tests.TestData;

internal static class OrderControllerTestData
{
    private static readonly Random random = new Random();

    public static List<OrderContract> ValidOrders
        => new List<OrderContract>
        {
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.NORMAL, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = null })
        };
}