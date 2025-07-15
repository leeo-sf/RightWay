using RightWay.Domain.Entity.Base;

namespace RightWay.Domain.Entity;

public record Driver(
    Guid Id, DateTime CreatedIn, DateTime UpdatedIn, string Name, string DriverLincenseNumber, string Phone) : BaseEntity(Id, CreatedIn, UpdatedIn);