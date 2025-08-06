namespace RightWay.Application.Validator.Messages;

public static class OrderMessage
{
    public static string NotEmptyOrder = "At least one order must be sent";
    public static string NotEmptyWeight = "The 'Weight' must be filled";
    public static string WeightGreatherThanPermitted = "Weight greater than permitted";
    public static string NotEmptyHeight = "The 'Height' must be filled";
    public static string HeightGreatherThanPermitted = "Height greater than permitted";
    public static string NotEmptyPriorityLevel = "The 'Priority Level' must be filled";
    public static string InvalidPriorityLevel = "The 'Priority Level' must be filled with the worst of the request. 0 = Low | 1 = Normal | 2 = Urgent";
    public static string AddressNotEmpty = "The 'Address' must be filled";
}