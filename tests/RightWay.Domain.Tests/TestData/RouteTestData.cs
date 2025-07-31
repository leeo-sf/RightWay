namespace RightWay.Domain.Tests.TestData;

internal static class RouteTestData
{
    public static IEnumerable<object[]> InvalidDate =>
        new List<object[]>
        {
            new object[] { DateTime.Now, DateTime.Now },
            new object[] { DateTime.Now.Subtract(TimeSpan.FromMinutes(1)), DateTime.Now.AddMinutes(200) },
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(120) },
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(481) },
            new object[] { DateTime.Now.AddDays(15).AddMinutes(1), DateTime.Now.AddDays(15).AddMinutes(120) },
            new object[] { DateTime.Now.AddDays(15).AddMinutes(1), DateTime.Now.AddDays(15).AddMinutes(481) }
        };

    public static IEnumerable<object[]> ValidDate =>
        new List<object[]>
        {
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(121) },
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(122) },
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(240) },
            new object[] { DateTime.Now.AddMinutes(1), DateTime.Now.AddMinutes(480) },
            new object[] { DateTime.Now.AddDays(10).AddMinutes(1), DateTime.Now.AddDays(10).AddMinutes(121) }
        };
}
