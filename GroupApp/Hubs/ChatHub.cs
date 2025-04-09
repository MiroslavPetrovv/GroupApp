using Microsoft.AspNetCore.SignalR;

namespace GroupApp.Hubs
{
    public class ChatHub : Hub  
    {
        public async Task SendMessage(string user, string message, string currentChannelId)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message, currentChannelId);
        }
    }
}
