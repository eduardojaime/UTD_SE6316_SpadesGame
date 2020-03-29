using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace AM_Spades
{
    public static class SocketHandler
    {
        /*private Socket[] listOfSockets = null;

            Socket[] listOfSockets = new Socket[5];
                //one server socket (what new players connect to), 4 client sockets to each of the other players
                //listOfSockets[0] = server socket
                //listOfSockets[1-4] = a player.
            //https://docs.python.org/2/howto/sockets.html
            //https://msdn.microsoft.com/en-us/library/system.net.sockets.socket%28v=vs.110%29.aspx
        }*/

        public static Socket CreateClientSocket(String machineNameOrIPAsString, int portNumber)
        {
            //TODO: Make a socket
            //See last paragraph of "Sockets" section for server sockets and client socket: https://docs.python.org/2/howto/sockets.html
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //AddressFamily.Internetwork = IPv4
            //TODO: Connect to the right location, according to the parameters
            return s;
        }

        public static Socket CreateServerSocket(int portNumber)
        {
            //TODO: Make a socket
            //See last paragraph of "Sockets" section for server sockets and client socket: https://docs.python.org/2/howto/sockets.html
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //AddressFamily.Internetwork = IPv4
            //TODO: Connect to the right location, according to the parameters
            return s;
        }

        public static void SendToSocket(Socket targetSocket, String msg)
        {
            //TODO: Send info through this socket
            //TODO: If we decide to make everything strings, with some specific format, keep this and delete the Message class
            //This is a wrapper function. Handle all the socket stuff here, so we can have a simple API in the game logic.
            //The example on the website made it look scary.
        }

        public static void SendToSocket(Socket targetSocket, Message msg)
        {
            //TODO: Send info through this socket
            //TODO: If we decide to make everything Message types, keep this and delete the String sending version
            //This is a wrapper function. Handle all the socket stuff here, so we can have a simple API in the game logic.
            //The example on the website made it look scary.
        }

        public static void ReadFromSocket(Socket targetSocket, String msg)
        {
            //TODO: Receive info from this socket
            //TODO: If we decide to make everything strings, with some specific format, keep this and delete the Message class
            //This is a wrapper function. Handle all the socket stuff here, so we can have a simple API in the game logic.
            //The example on the website made it look scary.
        }

        public static void ReadFromSocket(Socket targetSocket, Message msg)
        {
            //TODO: Receive info from this socket
            //TODO: If we decide to make everything Message types, keep this and delete the String sending version
            //This is a wrapper function. Handle all the socket stuff here, so we can have a simple API in the game logic.
            //The example on the website made it look scary.
        }
    }
}
