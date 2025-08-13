using System.ComponentModel;

namespace RightWay.Domain.Enum;

public enum OrderStatusEnum
{
    [Description("In Separation")]
    SEPARATION,
    [Description("Expedition")]
    EXPEDITION,
    [Description("Scheduled")]
    SCHEDULED,
    [Description("In Transit")]
    TRANSIT,
    [Description("Delivered")]
    DELIVERED,
    [Description("Failed")]
    FAILED
}