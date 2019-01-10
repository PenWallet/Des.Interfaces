using Microsoft.Owin;
using Owin;
using DardosServer;
using DardosServer.Gestora;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(DardosServer.Startup))]

namespace DardosServer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            GestoraCasilla.generarCasillas();
            GameInfo.globalScore = 0;
            GameInfo.personalScores = new Dictionary<string, int>();
            GameInfo.poppedBalloons = 0;
            GameInfo.numberOfPlayers = 0;
        }
    }
}