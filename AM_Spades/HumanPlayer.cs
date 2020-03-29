using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(String cName)
            :base(cName)
        {
        }
        //make sure extended methods call the parent's version of the method, like base.methodNameHere(), if you intended that.
    }
}
