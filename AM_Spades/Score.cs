using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM_Spades
{
    /// <summary>
    /// This class represents the score for a single player.
    /// </summary>
    class Score
    {
        int totalScore = 0;

        private int updateScore(int points) {
            totalScore = totalScore + points;
            return totalScore;
        }

        private int getScore() {
            return totalScore;
        }
    }
}
