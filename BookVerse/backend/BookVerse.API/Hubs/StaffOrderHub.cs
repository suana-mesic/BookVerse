using Microsoft.AspNetCore.SignalR;

namespace BookVerse.API.Hubs
{
    [Authorize(Policy = "Staff")]
    public class StaffOrderHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "staff", Context.ConnectionAborted);
            await base.OnConnectedAsync();
        }

    }
}
