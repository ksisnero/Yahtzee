using System;

namespace Yahtzee.Models
{
    public class Die
    {
        private Random random = new Random();

        public int Randomize()
        {
            int dieValue = random.Next(1, 7);
            return dieValue;
        }
    }
}
