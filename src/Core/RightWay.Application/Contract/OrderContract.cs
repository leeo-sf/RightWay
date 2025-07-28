using RightWay.Domain.Enum;

namespace RightWay.Application.Contract;

public record OrderContract(float Weight, float Height, PriorityLevelEnum PriorityLevel, AddressContract Address);