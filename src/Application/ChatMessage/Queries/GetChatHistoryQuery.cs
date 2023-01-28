using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application
{
    public record GetChatHistoryQuery : IRequest<PaginatedList<GetChatHistoryDto>>
    {
        public string user { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
}