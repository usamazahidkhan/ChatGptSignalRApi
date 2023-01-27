using CleanArchitecture.Application;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace CleanArchitecture.WebUI
{
    public class ChatHub : Hub
    {
        private readonly IMediator mediator;

        public ChatHub(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task SendMessage(SendMessageCommand command)
        {
            var response = await mediator.Send(command);

            await Clients.Caller.SendAsync("ReceiveMessage", response);
        }
    }
}