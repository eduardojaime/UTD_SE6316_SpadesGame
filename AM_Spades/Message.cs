using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    public class Message
    {
        int playerNumberOfSender;
        String message;

        public Message(int playerNumber, String msg)
        {
            playerNumberOfSender = playerNumber;
            message = msg;
        }

        public int getSenderNumber()
        {
            return playerNumberOfSender;
        }

        public String getMessage()
        {
            return message;
        }
    }
}
