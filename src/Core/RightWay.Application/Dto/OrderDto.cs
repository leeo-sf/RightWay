using RightWay.Domain.Enum;

namespace RightWay.Application.Dto;

public record OrderDto(Guid Id, float Weight, float Height, string PriorityLevel, string Status, AddressDto address);