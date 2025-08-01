using FluentAssertions.Execution;
using RightWay.Application.Contract;
using RightWay.Domain.Enum;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Emit;

namespace RightWay.Application.Tests.TestData;

internal class AddressTestData
{
    public static IEnumerable<object[]> ValidAddresses
    => new List<object[]>
    {
        new object[]
        {
            new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 10, Complement = null }
        },
        new object[]
        {
            new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.RJ, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 289, Complement = "Casa 02" }
        },
        new object[]
        {
            new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.MG, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 101, Complement = null }
        },
        new object[]
        {
            new AddressContract { ZipCode = "01001000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.SP, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 12 }
        },
        new object[]
        {
            new AddressContract { ZipCode = "01001-000", PublicPlace = "Praça da Sé", Neighborhood = "Sé", Locality = "São Paulo", Uf = StateEnum.PA, State = "São Paulo", Region = "Sudeste", MunicipalCode = 3550308, Number = 7892, Complement = "Deixar na recepção" }
        }
    };
}