using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application
{
    public class GetChatHistoryQueryHandler : IRequestHandler<GetChatHistoryQuery, PaginatedList<GetChatHistoryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetChatHistoryQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<GetChatHistoryDto>> Handle(GetChatHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _context.ChatMessages
                .Where(x => x.user == request.user)
                .OrderBy(x => x.created)
                .Select(x => new GetChatHistoryDto
                {
                    user = x.user,
                    message = x.message,
                    response = x.response
                })
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}