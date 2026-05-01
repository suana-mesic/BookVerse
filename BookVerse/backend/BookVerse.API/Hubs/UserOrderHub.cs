using Microsoft.AspNetCore.SignalR;

namespace BookVerse.API.Hubs
{
    [Authorize]
    public class UserOrderHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var userId = Context.UserIdentifier; //Takes NameIdentifier from claims
            if (!string.IsNullOrEmpty(userId)) {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"user-{userId}", Context.ConnectionAborted);
            }
            await base.OnConnectedAsync();
        }
    }
}
