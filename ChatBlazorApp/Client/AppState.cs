using ChatBlazorApp.Client.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBlazorApp.Client
{
    public class AppState
    {
        public string UserName { get; set; }

        public Dictionary<string, int> Rooms = new Dictionary<string, int>();

        public string RoomsCommaSeperated { get; set; }

        public Action AppStateUpdated { get; set; }

        public Room CurrentRoom { get; set; }
    }
}
