using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    using WindowsFormsApplication1; //to use the enums in Form1

    public class Deck
    {
       //static String[] cards = new String[52];
       static Card[] cards = new Card[52];

        private static void createDeck()
        {
            int cardIndex = 0;

            //For each suit
            foreach (Suit suitAsString in Enum.GetValues(typeof(Suit)))
            {
                //For each value within a suit
                foreach (int value in Enum.GetValues(typeof(Value)))
                { 
                    cards[cardIndex] = new Card(suitAsString.ToString(), value, false);
                    cardIndex++;
                }
            }

            /*
            cards[0] = "c1";
            cards[1] = "c2";
            cards[2] = "c3";
            cards[3] = "c4";
            cards[4] = "c5";
            cards[5] = "c6";
            cards[6] = "c7";
            cards[7] = "c8";
            cards[8] = "c9";
            cards[9] = "c10";
            cards[10] = "c11";
            cards[11] = "c12";
            cards[12] = "c13";
            cards[13] = "s1";
            cards[14] = "s2";
            cards[15] = "s3";
            cards[16] = "s4";
            cards[17] = "s5";
            cards[18] = "s6";
            cards[19] = "s7";
            cards[20] = "s8";
            cards[21] = "s9";
            cards[22] = "s10";
            cards[23] = "s11";
            cards[24] = "s12";
            cards[25] = "s13";
            cards[26] = "h1";
            cards[27] = "h2";
            cards[28] = "h3";
            cards[29] = "h4";
            cards[30] = "h5";
            cards[31] = "h6";
            cards[32] = "h7";
            cards[33] = "h8";
            cards[34] = "h9";
            cards[35] = "h10";
            cards[36] = "h11";
            cards[37] = "h12";
            cards[38] = "h13";
            cards[39] = "d1";
            cards[40] = "d2";
            cards[41] = "d3";
            cards[42] = "d4";
            cards[43] = "d5";
            cards[44] = "d6";
            cards[45] = "d7";
            cards[46] = "d8";
            cards[47] = "d9";
            cards[48] = "d10";
            cards[49] = "d11";
            cards[50] = "d12";
            cards[51] = "d13";*/
        }

        public static Card[] shuffleAndSplit()
        {
            createDeck();
            Random random = new Random();
            for (int i = 0; i < cards.Length - 1; i += 1)
            {
                int swapIndex = random.Next(i, cards.Length);
                if (swapIndex != i)
                {
                    Card temp = cards[i];
                    cards[i] = cards[swapIndex];
                    cards[swapIndex] = temp;
                }
            }
           return cards;
        }
    }
}
