using ChatBlazorApp.Server.Data;
using ChatBlazorApp.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBlazorApp.Server.Hubs
{
    public class ChatHub : Hub
    {
		private readonly PreviousChatArchive previousChatArchive;

		public ChatHub(PreviousChatArchive previousChatArchive)
		{
			this.previousChatArchive = previousChatArchive;
		}

		public async Task JoinRoom(string roomName)
		{
			await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
		}

        public async Task SendMessage(string user, string message, string roomName)
		{
			ChatData chatData = new Shared.ChatData { User = user, Message = message };

			if (previousChatArchive.Chats.ContainsKey(roomName))
			{
				previousChatArchive.Chats[roomName].Add(chatData);
			}
			else
			{
				previousChatArchive.Chats.Add(roomName, new List<Shared.ChatData> { chatData });
			}
			
            await Clients.Group(roomName).SendAsync("ReceiveMessage", user, message);
		}
    }
}
