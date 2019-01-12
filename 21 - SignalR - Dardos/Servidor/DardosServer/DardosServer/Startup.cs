using Microsoft.Owin;
using Owin;
using DardosServer.Gestora;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using System;
using DardosServer.Models;

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
            GameInfo.jugadores = new Dictionary<string, Jugador>();
            GameInfo.poppedBalloons = 0;
            GameInfo.numberOfPlayers = 0;
            GameInfo.colors = loadColors();

            //Marcar un usuario como desconectado tras 5 segundos
            GlobalHost.Configuration.DisconnectTimeout = TimeSpan.FromSeconds(6);
        }

        private List<Color> loadColors()
        {
            List<Color> listadoColores = new List<Color>();
            listadoColores.Add(new Color("Blue", true));
            listadoColores.Add(new Color("Red", true));
            listadoColores.Add(new Color("Purple", true));
            listadoColores.Add(new Color("Brown", true));
            listadoColores.Add(new Color("Yellow", true));
            listadoColores.Add(new Color("Pink", true));
            listadoColores.Add(new Color("Black", true));
            listadoColores.Add(new Color("Gray", true));
            listadoColores.Add(new Color("Green", true));
            listadoColores.Add(new Color("GreenYellow", true));
            listadoColores.Add(new Color("Salmon", true));
            listadoColores.Add(new Color("Plum", true));

            return listadoColores;
        }
    }
}