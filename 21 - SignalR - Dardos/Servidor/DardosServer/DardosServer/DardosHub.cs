using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DardosServer.Models;

namespace DardosServer
{
    public class DardosHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Press(int posBalloon)
        {

        }
    }
}