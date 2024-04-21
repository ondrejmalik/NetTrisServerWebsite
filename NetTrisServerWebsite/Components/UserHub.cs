using Microsoft.AspNetCore.SignalR;

namespace BlazorApp2.Components.Pages;

public class UserHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public async Task SendMessage(int count)
    {
        try
        {
            await Clients.All.SendAsync("ReceiveMessage", count);
        }
        catch (Exception e)
        {
            ;
        }
    }
}