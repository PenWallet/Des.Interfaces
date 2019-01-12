using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DardosServer.Models;

namespace DardosServer.Gestora
{
    public static class GameInfo
    {
        public static readonly int numberOfBalloons = 10;
        public static readonly int numberOfTiles = 30;
        public static List<Casilla> casillas { get; set; }
        public static int globalScore { get; set; }
        public static IDictionary<string, Jugador> jugadores { get; set; }
        public static int poppedBalloons { get; set; }
        public static int numberOfPlayers { get; set; }
        public static List<Color> colors { get; set; }
    }
}