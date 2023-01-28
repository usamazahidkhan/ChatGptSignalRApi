using CleanArchitecture.Application;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHistoryController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetChatHistoryDto>>> GetChatHistory([FromQuery] GetChatHistoryQuery query)
        {
            return await mediator.Send(query);
        }
    }
}
