using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Game
    {
        List<int> rolls = new List<int>();        
       
        int frameCount = 1;
        int rollCount = 0;
        const int MaxRoll = 2;
         
        public void Roll(int pin)
        {
            rolls.Add(pin);
           
            if (rollCount == MaxRoll)
            {
                if (frameCount < 10)
                    frameCount++;
                rollCount = 0;
            }

            rollCount++;

            if (pin == 10)
            {
                rollCount = MaxRoll;
            }            
        }

        public int Score()
        {
            var roll = 0;
            var frameScores = new List<int>();

            for (var frame = 0; frame < frameCount; frame++)
            {
                var fScore = 0; 

                if (IsStrike(roll)) //check if Strike
                {
                    fScore += 10 + rolls[roll + 1] + rolls[roll + 2];
                    frameScores.Add(fScore);
                    roll++;
                }
                else if (IsSpare(roll))//check if Spare
                {
                    fScore += 10 + rolls[roll + 2];
                    frameScores.Add(fScore);
                    roll += 2;
                }
                else
                {
                    if (roll + 1 != rolls.Count)
                        fScore += rolls[roll] + rolls[roll + 1];
                    else
                        fScore += rolls[roll];

                    frameScores.Add(fScore);
                    roll += 2;
                }
            }

            return frameScores.Sum();
        }

        private bool IsStrike(int roll)
        {
            return roll + 1 != rolls.Count && rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return roll + 1 != rolls.Count && rolls[roll] + rolls[roll + 1] == 10;
            
        }
    }
}
