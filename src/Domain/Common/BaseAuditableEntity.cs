namespace CleanArchitecture.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime created { get; set; }

    public string? createdBy { get; set; }

    public DateTime? lastModified { get; set; }

    public string? lastModifiedBy { get; set; }
}
