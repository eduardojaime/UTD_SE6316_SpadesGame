using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AM_Spades
{
    using WindowsFormsApplication1;//to use the enums in form1

    public class Card:IComparable<Card> //implements IComparable interface so we can just use List's Sort() method on the cards
    {
        //suit 
        private String suit;
        private int value;
        private Boolean isHidden;
        private Dictionary<String, int> stringToWeightValue;

        public Card()
        {
            suit = null;
            value = -1;
            isHidden = false;

            stringToWeightValue = new Dictionary<string, int>();
            stringToWeightValue.Add("Spades", 60);
            stringToWeightValue.Add("Hearts", 40);
            stringToWeightValue.Add("Diamonds", 20);
            stringToWeightValue.Add("Clubs", 0);
        }

        public Card(String tempSuit, int tempValue, Boolean hiddenness)
        {
            suit = tempSuit;
            value = tempValue;
            isHidden = hiddenness;

            stringToWeightValue = new Dictionary<string, int>();
            stringToWeightValue.Add("Spades", 60);
            stringToWeightValue.Add("Hearts", 40);
            stringToWeightValue.Add("Diamonds", 20);
            stringToWeightValue.Add("Clubs", 0);
        }

        //Remember to typecast the returned value into a Suit
        public String GetSuit()
        {
            return suit;
        }

        //Remember to typecast the returned value into a Suit
        public int GetValue()
        {
            return value;
        }

        public static String GetImageLocationOfCard(Card desiredCard)
        {
            String output = "";
            if (desiredCard.GetIsHidden() == false)
                output = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + Char.ToLower(desiredCard.GetSuit()[0]) + desiredCard.GetValue() + ".png"; //gets first char of getSuit()
            else
                output = AppDomain.CurrentDomain.BaseDirectory + "\\cards\\" + "b1fv" + ".png"; //this is the blue back card

            return output;
        }

        public Boolean GetIsHidden()
        {
            return isHidden;
        }

        public void SetIsHidden(Boolean newHiddenness)
        {
            isHidden = newHiddenness;
        }

        public override String ToString()
        {
            String output = "";
            output += "suit = " + suit + "\n";
            output += "value = " + value + "\n";
            output += "isHidden = " + isHidden + "\n";
            return output;
        }

        public int CompareTo(Card other)
        {
            //Basically, rank cards by suit. Then by value. Spades is biggest. See weights in Card constructors.
            int output;
            if (suit.Equals(other.GetSuit()) && value == other.GetValue())
                output = 0;//0 means they're the same
            else
            {
                output = (stringToWeightValue[other.GetSuit()] + other.GetValue()) - (stringToWeightValue[suit] + value);
            }

            return output;
        }
    }
}
