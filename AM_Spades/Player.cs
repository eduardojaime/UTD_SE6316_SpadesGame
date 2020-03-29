using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    public class Player
    {
        protected String name;
        protected int score;
        protected List<Card> myHand;
        protected int bid = 0;
        protected int currenttrick = 0;
        protected int remainingtrick = 0;

        public Player(String pName)
        {
            name = pName;
            score = 0;
            myHand = new List<Card>();
        }

        public String GetName()
        {
            return name;
        }

        public void SetName(String newName)
        {
            name = newName;
        }

        public virtual void CreateHand(Card[] arrayVersionOfHand)
        {
            myHand = new List<Card>(arrayVersionOfHand);
            myHand.Sort();
        }

        public List<Card> GetHand()
        {
            return myHand;
        }

        public void AddCardToHand(Card daCard)
        {
            myHand.Add(daCard);
        }

        /*public Card getCardAndRemoveFromHand(Card desiredCard)
        {
            Boolean cardExistsInHand = myHand.Remove(desiredCard);
            return de
        }*/

        public int GetScore()
        {
            return score;
        }

        public void SetScore(int tempScore)
        {
            score = tempScore;
        }

        public int GetBid()
        {
            return bid;
        }

        public void SetBid(int tempBid)
        {
            bid = tempBid;
        }

        public int GetCurrentTrick()
        {
            return currenttrick;
        }

        public void SetCurrentTrick(int tempcurrtrick)
        {
            currenttrick = tempcurrtrick;
        }

        public int GetRemainingTrick()
        {
            return remainingtrick;
        }

        public void SetRemainingTrick(int tempremrtrick)
        {
            remainingtrick = tempremrtrick;
        }


        public override String ToString()
        {
            String output = "";
            output += "==============\n";
            output += "name = " + name + "\n";
            output += "score = " + score + "\n";
            output += "myHand = " + string.Join<Card>("---------\n", myHand.ToArray());
            output += "==============";
            return output;
        }


        public Card PlayRound()
        {
            List<Card> Cards = GetHand();
            foreach(Card currCard in Cards) {
                if (currCard.GetIsHidden()) {
                    currCard.SetIsHidden(false);
                    return currCard;
                }
                else { }
            }
            return null;
        }
    }
}
