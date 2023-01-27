using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace CleanArchitecture.Application
{
    public record SendMessageCommand : IRequest<string>
    {
        public string user { get; init; }
        public string message { get; init; }
    }

    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IOpenAIService openAIService;

        public SendMessageCommandHandler(IApplicationDbContext context, IOpenAIService openAIService)
        {
            _context = context;
            this.openAIService = openAIService;
        }

        public async Task<string> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            return await GetOpenAIResponse(request);
        }

        private async Task<string> GetOpenAIResponse(SendMessageCommand request)
        {
            var completionResult = await openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = request.message,
                Model = Models.TextDavinciV3
            });

            if (completionResult.Successful)
            {
                return completionResult.Choices.FirstOrDefault()?.Text;
            }

            if (completionResult.Error == null)
            {
                throw new Exception("Unknown Error");
            }

            throw new Exception($"{completionResult.Error.Code}: {completionResult.Error.Message}");
        }

    }
}
