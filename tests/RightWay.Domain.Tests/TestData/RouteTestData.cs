namespace RightWay.Domain.Tests.TestData;

internal static class RouteTestData
{
    public static IEnumerable<object[]> InvalidDate()
    {
        var currentDateTime = DateTime.Now;
        return new List<object[]>
        {
            new object[] { currentDateTime, currentDateTime },
            new object[] { currentDateTime.Subtract(TimeSpan.FromMinutes(1)), currentDateTime.AddMinutes(201) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(121) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(483) },
            new object[] { currentDateTime.AddDays(15).AddMinutes(2), currentDateTime.AddDays(15).AddMinutes(121) },
            new object[] { currentDateTime.AddDays(15).AddMinutes(2), currentDateTime.AddDays(15).AddMinutes(483) }
        };
    }

    public static IEnumerable<object[]> ValidDate()
    {
        var currentDateTime = DateTime.Now;
        return new List<object[]>
        {
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(122) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(123) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(241) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(481) },
            new object[] { currentDateTime.AddMinutes(2), currentDateTime.AddMinutes(482) },
            new object[] { currentDateTime.AddDays(10).AddMinutes(2), currentDateTime.AddDays(10).AddMinutes(122) }
        };
    }
}
