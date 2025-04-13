using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace GroupApp.Hubs
{
    [Authorize]
    public class ChatHub : Hub  
    {
        public async Task SendMessage(string user, string message, string currentChannelId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, currentChannelId);
        }
        public override Task OnConnectedAsync()
        {

            return base.OnConnectedAsync();
        }
    }
}
