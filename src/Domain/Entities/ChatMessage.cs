namespace CleanArchitecture.Domain.Entities;

public class ChatMessage : BaseAuditableEntity
{
    public string user { get; set; }
    public string message { get; set; }
    public string response { get; set; }
}
