//Note from Hieu: I think we should refactor all of the deck/hands/logic into this class.
//Form1 will be the "View" in MVC (Model View Controller)
//This (GameModel) will be the "Model"
//...but it's late and I don't want to rewrite all the stuff in Form1, for now.
//-10/26/2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    public class GameModel
    {
        List<Player> currentPlayers;
        int turnNumber;
        String playerName = "JOHN";
        String computer1Name = "ComputerPlayer1";
        String computer2Name = "ComputerPlayer2";
        String computer3Name = "ComputerPlayer3";

        public GameModel()
        {
            turnNumber = 0;

            //Creating players
            currentPlayers = new List<Player>();
            currentPlayers.Add(new HumanPlayer(playerName));
            currentPlayers.Add(new ComputerPlayer(computer1Name));
            currentPlayers.Add(new ComputerPlayer(computer2Name));
            currentPlayers.Add(new ComputerPlayer(computer3Name));

            //Giving cards to players
            Card[] deckAsArray = Deck.shuffleAndSplit();
            Card[] tempArray = new Card[13];

            //Copy 13 elements from deckAsArray to tempArray, starting at (index 0 of deckAsArray) and (index 0 of tempArray)
            //then get desired player from currentPlayers, then CreateHand using tempArray
            Array.Copy(deckAsArray, 0, tempArray, 0, 13); 
            currentPlayers.Find(x => x.GetName().Equals(playerName)).CreateHand(tempArray);

            Array.Copy(deckAsArray, 13, tempArray, 0, 13);
            currentPlayers.Find(somePlayer => somePlayer.GetName().Equals(computer1Name)).CreateHand(tempArray);

            Array.Copy(deckAsArray, 26, tempArray, 0, 13);
            currentPlayers.Find(somePlayer => somePlayer.GetName().Equals(computer2Name)).CreateHand(tempArray);

            Array.Copy(deckAsArray, 39, tempArray, 0, 13);
            currentPlayers.Find(somePlayer => somePlayer.GetName().Equals(computer3Name)).CreateHand(tempArray);

            /*
            Console.WriteLine(currentPlayers.Find(x => x.GetName().Equals(playerName)));//DEBUG
            Console.WriteLine(currentPlayers.Find(x => x.GetName().Equals(computer1Name)));//DEBUG
            Console.WriteLine(currentPlayers.Find(x => x.GetName().Equals(computer2Name)));//DEBUG
            Console.WriteLine(currentPlayers.Find(x => x.GetName().Equals(computer3Name)));//DEBUG
            */
        }

        public List<Player> GetPlayers()
        {
            return currentPlayers;
        }
    }
}
