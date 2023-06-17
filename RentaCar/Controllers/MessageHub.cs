using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace RentaCar.Controllers
{
    [EnableCors("HubPolicy")]
    public class MessageHub : Hub
    {
        //Send message to clientside
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
