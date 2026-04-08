using Microsoft.AspNetCore.SignalR;

namespace Market.API.Hubs
{
    [Authorize(Policy ="AdminOnly")]
    public class AdminOrderHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // Only admins can connect to this hub
            await Groups.AddToGroupAsync(Context.ConnectionId, "admins");
            await base.OnConnectedAsync();
        }

    }
}
