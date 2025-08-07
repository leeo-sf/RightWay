namespace RightWay.Ioc.Tests.TestData;

internal static class DependenciesTestData
{
    public static Dictionary<string, string> ServiceTestSettings()
        => new Dictionary<string, string>
        {
            { "Service", "Test" },
            { "ConnectionsStrings:Database", "mydb:string" }
        };
}