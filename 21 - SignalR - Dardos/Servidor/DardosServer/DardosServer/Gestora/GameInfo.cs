using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DardosServer.Models;

namespace DardosServer.Gestora
{
    public static class GameInfo
    {
        public static List<Casilla> casillas { get; set; }
        public static int globalScore { get; set; }
        public static IDictionary<string, int> personalScores { get; set; }
        public static int poppedBalloons { get; set; }
        public static int numberOfPlayers { get; set; }
    }
}