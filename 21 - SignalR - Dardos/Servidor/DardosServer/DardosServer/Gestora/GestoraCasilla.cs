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
            Casilla globo = new Casilla(0, true, false);
            Casilla noGlobo = new Casilla();
            Casilla[] casillas = new Casilla[16];

            //Son globos: 0, 2, 3, 9, 12, 13, 15
            casillas[0] = new Casilla(0, true, false);
            casillas[2] = new Casilla(2, true, false);
            casillas[3] = new Casilla(3, true, false);
            casillas[9] = new Casilla(9, true, false);
            casillas[12] = new Casilla(12, true, false);
            casillas[13] = new Casilla(13, true, false);
            casillas[15] = new Casilla(15, true, false);

            //Los demás no lo son
            casillas[1] = new Casilla(1, false, false);
            casillas[4] = new Casilla(4, false, false);
            casillas[5] = new Casilla(5, false, false);
            casillas[6] = new Casilla(6, false, false);
            casillas[7] = new Casilla(7, false, false);
            casillas[8] = new Casilla(8, false, false);
            casillas[10] = new Casilla(10, false, false);
            casillas[11] = new Casilla(11, false, false);
            casillas[14] = new Casilla(14, false, false);

            GameInfo.casillas = casillas;
        }

        /*public static bool checkAllBalloonsPopped()
        {
            bool allPopped = true;
            Casilla casilla;
            for(int i = 0; i < GameInfo.casillas.Length && allPopped; i++)
            {
                casilla = GameInfo.casillas[i];
                if (casilla.isBalloon && !casilla.isPopped)
                    allPopped = false;

                //allPopped = !(casilla.isBalloon && !casilla.isPopped);
            }

            return allPopped;
        }*/
    }
}