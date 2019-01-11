using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using DardosServer.Models;
using DardosServer.Gestora;
using System.Threading.Tasks;

namespace DardosServer
{
    public class DardosHub : Hub
    {
        public void press(int posBalloon)
        {
            //En caso de que alguien haya pulsado antes, nos aseguramos de que el globo sigue sin ser explotado
            if(!GameInfo.casillas[posBalloon].isPopped)
            {
                //Explotamos el globo en los otros clientes
                GameInfo.casillas[posBalloon].popBalloon();
                Clients.All.popBalloon(posBalloon);
                GameInfo.poppedBalloons++;
                GameInfo.globalScore++;

                //Le damos el punto por explotar el globo al jugador que lo haya explotado
                Clients.Caller.addOnePoint();
                GameInfo.personalScores[Context.ConnectionId]++;

                //Actualizamos la puntuación global de todos los jugadores
                Clients.All.updateGlobalScore(GameInfo.globalScore);

                //Si ya no quedan globos por explotar
                if (GameInfo.poppedBalloons == 7)
                {
                    GameInfo.poppedBalloons = 0;
                    GestoraCasilla.generarCasillas();
                    Clients.All.loadBalloons(GameInfo.casillas);
                }
            }
        }

        //Cuando un jugador se desconecte
        public override Task OnDisconnected(bool stopCalled)
        {
            //Cuando se desconecte, quitamos su entrada del diccionario
            GameInfo.personalScores.Remove(Context.ConnectionId);

            //Restamos uno al número de jugadores concurrentes
            GameInfo.numberOfPlayers--;
            Clients.All.updateNumberOfPlayers(GameInfo.numberOfPlayers);

            return base.OnDisconnected(stopCalled);
        }

        //Cuando un jugador se conecte
        public override Task OnConnected()
        {
            //Cuando se conecte, agregamos su entrada al diccionario
            GameInfo.personalScores.Add(Context.ConnectionId, 0);

            //Sumamos uno al número de jugadores concurrentes
            GameInfo.numberOfPlayers++;
            Clients.All.updateNumberOfPlayers(GameInfo.numberOfPlayers);

            //Le mandamos la información de la partida
            Clients.Caller.loadBalloons(GameInfo.casillas);
            Clients.Caller.updateGlobalScore(GameInfo.globalScore);

            return base.OnConnected();
        }
    }
}