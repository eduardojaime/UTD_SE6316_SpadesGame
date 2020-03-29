using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace AM_Spades
{
    //Some computer runs this. It could be one of the players or some 5th computer.
    class GameServer
    {
        static void Main()
        {
            int initialConnectionPort = 7492;
            int numberOfPlayers = 4;
            int currentPlayerTurn = 1;
            Boolean gameOver = false;

            Socket initialConnectionSocket;
            Socket player1Socket;
            Socket player2Socket;
            Socket player3Socket;
            Socket player4Socket;

            //Following is pseudo code, assuming the methods work as I want them to
            GameModel canonicalGameModel = new GameModel();

            initialConnectionSocket = SocketHandler.CreateServerSocket(initialConnectionPort);

            //do synchronous stuff. See da Internet: https://msdn.microsoft.com/en-us/library/6y0e13d3%28v=vs.110%29.aspx
            //player1Socket = whatever the server socket spits out when it receives the connect message//using port 0 asks the OS to give you some usable port.
            //player2Socket = whatever the server socket spits out when it receives the connect message
            //player3Socket = whatever the server socket spits out when it receives the connect message
            //player4Socket = whatever the server socket spits out when it receives the connect message


            while (!gameOver)
            {
                //If canonicalGameModel says it's player1's turn:
                //SocketHandler.SendToSocket(player1Socket, "It's your turn" message as defined in the "Message types" spreadsheet on Google Drive)
                //receive player1's response. Update canonicalGameModel.

                //If canonicalGameModel says it's player2's turn:
                //SocketHandler.SendToSocket(player2Socket, "It's your turn" message as defined in the "Message types" spreadsheet on Google Drive)
                //receive player2's response. Update canonicalGameModel.

                //If canonicalGameModel says it's player3's turn:
                //SocketHandler.SendToSocket(player3Socket, "It's your turn" message as defined in the "Message types" spreadsheet on Google Drive)
                //receive player3's response. Update canonicalGameModel.

                //If canonicalGameModel says it's player4's turn:
                //SocketHandler.SendToSocket(player1Socket, "It's your turn" message as defined in the "Message types" spreadsheet on Google Drive)
                //receive player4's response. Update canonicalGameModel.

                //If game is over
                //send "You won!" message to the winner
                //send "You lost!" message to the loser
            }
        }
    }
}
