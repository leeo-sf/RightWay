namespace RightWay.Application.Validator.Messages;

internal static class AddressMessage
{
    public static string AddressNotEmpty = "The 'Addresses' must be filled in";
    public static string ZipCodeNotEmpty = "The 'Zip Code' must be filled in";
    public static string ZipCodeMaximumSize = "The 'Zip Code' exceeded the allowed size";
    public static string ZipCodeMinimumSize = "The 'Zip Code' filled in is incorrect";
    public static string PublicPlaceNotEmpty = "The 'Public Place' must be filled in";
    public static string PublicPlaceMaximumSize = "The 'Public Place' exceeded the allowed size";
    public static string NeighborhoodNotEmpty = "The 'Neighborhood' must be filled in";
    public static string NeighborhoodMaximumSize = "The 'Neighborhood' exceeded the allowed size";
    public static string LocalityNotEmpty = "The 'Locality' must be filled in";
    public static string LocalityMaximumSize = "The 'Locality' exceeded the allowed size";
    public static string StateNotEmpty = "The 'State' must be filled in";
    public static string StateMaximumSize = "The 'State' exceeded the allowed size";
    public static string RegionNotEmpty = "The 'Region' must be filled in";
    public static string RegionMaximumSize = "The 'Region' exceeded the allowed size";
    public static string MunicipalCodeNotEmpty = "The 'Municipal Code' must be filled in";
    public static string NegativeMunicipalCode = "The 'Municipal Code' cannot be negative";
    public static string NumberNotEmpty = "The 'Number' must be filled in";
    public static string NegativeNumber = "The address number cannot be negative";
}