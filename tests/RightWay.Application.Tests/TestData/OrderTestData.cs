using RightWay.Application.Contract;
using RightWay.Domain.Entity;
using RightWay.Domain.Enum;

namespace RightWay.Application.Tests.TestData;

internal static class OrderTestData
{
    private static readonly Random random = new Random();

    public static List<OrderContract> ValidOrdersToBeCreated
        => new List<OrderContract>
        {
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.NORMAL, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = null }),
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.LOW, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = "Esquina" }),
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.NORMAL, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = null }),
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.URGENT, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = "Casa 01" }),
            new((float)(random.NextDouble() * (50 - 0.1) + 0.1), (float)(random.NextDouble() * (1.50 - 0.1) + 0.1), PriorityLevelEnum.NORMAL, new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = random.Next(9999), Complement = "Deixar na recepção" })
        };
}