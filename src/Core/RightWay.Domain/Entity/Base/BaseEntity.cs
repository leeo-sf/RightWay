using System.ComponentModel.DataAnnotations.Schema;

namespace RightWay.Domain.Entity.Base;

public abstract record BaseEntity(
    [property: NotMapped] Guid id,
    [property: NotMapped] DateTime createdIn,
    [property: NotMapped] DateTime updatedIn)
{
    public Guid Id { get; } = id;
    public DateTime CreatedIn { get; } = createdIn.ToUniversalTime();
    public DateTime UpdatedIn { get; } = updatedIn.ToUniversalTime();
}