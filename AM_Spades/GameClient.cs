using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace AM_Spades
{
    //Computers the player intereacts with runs this
    class GameClient
    {
        static void Main()
        {
            int initialConnectionPort = 7492;
            Boolean gameOver = false;

            GameModel localViewOfGame = new GameModel();

            Socket socketToServer = SocketHandler.CreateClientSocket("machineNameOrIPOfServer", initialConnectionPort);

            //do synchronous socket stuff

            //SocketHandler.SendMessage(socketToServer, "My name is _" message);

            while (!gameOver)
            {
                //if you receive "It's your turn" message from the server
                //Do stuff to your localViewOfGame (like activate GUI. Ask user what card to play, etc.)

                //if you receive "Player X played this card" message
                //Update localViewOfGame

                //if you receive "You won!" message
                //Update localViewOfGame

                //if you receive "You lost!" message
                //Update localViewOfGame
            }
        }
    }
}
