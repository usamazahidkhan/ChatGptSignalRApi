namespace CleanArchitecture.Domain.Entities;

public class ChatMessage : BaseAuditableEntity
{
    public string message { get; set; }
    public string messageBy { get; set; }
}
