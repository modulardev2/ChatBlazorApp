using ChatBlazorApp.Server.Data;
using ChatBlazorApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBlazorApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
		private readonly PreviousChatArchive previousChatArchive;

		public ChatController(PreviousChatArchive previousChatArchive)
		{
			this.previousChatArchive = previousChatArchive;
		}

		[HttpGet("{roomName}")]
		public IEnumerable<ChatData> Get([FromRoute] string roomName)
		{
			if (previousChatArchive.Chats.ContainsKey(roomName))
				return previousChatArchive.Chats[roomName];
			return new ChatData[0];
		}
	}
}
