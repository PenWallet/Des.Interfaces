using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DardosServer.Models;

namespace DardosServer.Gestora
{
    public static class GestoraJugadores
    {
        //Devuelve true si está disponible, false si no lo está
        public static bool checkUsernameAvailability(string username)
        {
            foreach (var jugador in GameInfo.jugadores.Values)
            {
                if (username == jugador.nombre)
                    return false;
            }

            return true;
        }
    }
}