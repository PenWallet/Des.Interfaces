using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DardosServer.Models;

namespace DardosServer.Gestora
{
    public class GestoraCasilla
    {
        public Casilla[] generarCasillas()
        {
            Casilla globo = new Casilla(true, false);
            Casilla noGlobo = new Casilla();
            Casilla[] casillas = { globo, noGlobo, globo, globo, noGlobo, noGlobo, noGlobo, noGlobo, noGlobo, globo, noGlobo, noGlobo, globo, globo, noGlobo, globo };
        }
    }
}