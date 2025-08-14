using System.ComponentModel;

namespace RightWay.Domain.Enum;

public enum OrderStatusEnum
{
    [Description("In Separation")]
    SEPARATION,
    [Description("Expedition")]
    EXPEDITION,
    [Description("Dispatched")]
    DISPATCH,
    [Description("In Transit")]
    TRANSIT,
    [Description("Delivered")]
    DELIVERED,
    [Description("Failed")]
    FAILED
}