using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DardosServer.Models;

namespace DardosServer.Gestora
{
    public static class GestoraCasilla
    {
        public static void generarCasillas()
        {
            List<Casilla> casillasShuffled = new List<Casilla>();
            int globosInsertados = 0;

            for (; globosInsertados < GameInfo.numberOfBalloons; globosInsertados++)
            {
                casillasShuffled.Add(new Casilla(true, false));
            }
            for (; globosInsertados < GameInfo.numberOfTiles; globosInsertados++)
            {
                casillasShuffled.Add(new Casilla());
            }

            shuffle(ref casillasShuffled);

            GameInfo.casillas = casillasShuffled;
        }

        #region Métodos aportados por Nachete
        private static void shuffle(ref List<Casilla> casillas)
        {
            Random random = new Random();

            for (int i = casillas.Count - 1; i > 0; i--)
            {
                int toSwap = random.Next(0, i);
                swap(ref casillas, i, toSwap);
            }
        }
        
        private static void swap(ref List<Casilla> casillas, int indexOne, int indexTwo)
        {
            Casilla log = casillas[indexOne];
            casillas[indexOne] = casillas[indexTwo];
            casillas[indexTwo] = log;
        }
        #endregion
    }
}