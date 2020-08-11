using ChatBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBlazorApp.Server.Data
{
    public class PreviousChatArchive
    {
        public Dictionary<string, List<ChatData>> Chats { get; set; } = new Dictionary<string, List<ChatData>>();
    }
}
