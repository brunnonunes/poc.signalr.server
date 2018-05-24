﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace poc.signalr.api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendSimpleMessage(string message) {
            await Clients.All.SendAsync("ReceiveSimpleMessage", message);
        }
    }
}