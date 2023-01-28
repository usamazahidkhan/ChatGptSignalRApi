namespace CleanArchitecture.Application
{
    public record GetChatHistoryDto
    {
        public string user { get; set; }
        public string message { get; set; }
        public string response { get; set; }
    }
}

