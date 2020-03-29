using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    public class ComputerPlayer : Player //ComputerPlayer is a subclass of Player
    {
        public ComputerPlayer(String cName)
            : base(cName)
        {
        }

        public override void CreateHand(Card[] arrayVersionOfHand)
        {
            base.CreateHand(arrayVersionOfHand);
            //Hiding the comptuer cards. Actual image picking is handled when retrieving image urls in Card class
            foreach (Card currCard in myHand)
            {
                currCard.SetIsHidden(true);
                String sSuit = currCard.GetSuit();
                if (sSuit == "Spades")
                {
                    bid += 1;
                }
            }
        }

       
    }
}
