using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Models
{
    public class ScoreCard
    {
        private List<int> DiceValues;

        public ScoreCard(List<int> dice)
        {
            DiceValues = dice;
        }

        public int Sum()
        {
            int sum = DiceValues.Sum();
            return sum;
        }

        public int SumInstancesOfNumber(int numberToFind, bool buttonIsEnabled)
        {
            int score = 0;

            foreach (int numericalValue in DiceValues)
            {
                if (numericalValue == numberToFind && buttonIsEnabled)
                    score += numberToFind;
            }
            return score;
        }

        public int OfAKind(bool buttonIsEnabled)
        {
            int score = 0;

            foreach (int numericalValue in DiceValues)
            {
                //if the same number appears 3 times...display points (and so on)
                int diceValueCount = DiceValues.Count(c => c == numericalValue);

                if (buttonIsEnabled && diceValueCount == 3)   //Three of a kind
                    score = Sum();
                if (buttonIsEnabled && diceValueCount == 4)   //Four of a kind
                    score = Sum();
            }
            return score;
        }

        public int Yahtzee(bool buttonIsEnabled)
        {
            int score = 0;

            foreach (int numericalValue in DiceValues)
            {
                int diceValueCount = DiceValues.Count(c => c == numericalValue);

                if (buttonIsEnabled && diceValueCount == 5)
                    score = Sum();
            }
            return score;
        }

        public int FullHouse(bool buttonIsEnabled)
        {
            int score = 0;

            foreach (int numericalValue in DiceValues)
            {
                var diceValueCount = DiceValues.Count(v => v == numericalValue);
            }
            //var fullHouseExists = group diceValueCount
            //var fullHouseExists = diceValueIterations.Exists(v => v == 2 && v == 3);
            //if (fullHouseExists && buttonIsEnabled)
            //    score = 25;

            return score;
        }

        public int SmallStraight(bool buttonIsEnabled)
        {
            int score = 0;

            var smallStraights = new List<List<int>>
            {
                new List<int> {1, 2, 3, 4},
                new List<int> {2, 3, 4, 5},
                new List<int> {3, 4, 5, 6}
            };

            var smallStraightsExists = smallStraights.Exists(x => x.Intersect(DiceValues).Count() == 4);

            if (smallStraightsExists && buttonIsEnabled)
                score = 30;

            return score;
        }

        public int LargeStraight(bool buttonIsEnabled)
        {
            int score = 0;

            DiceValues.Sort();
            var largeStraightsExists = DiceValues.Count() == 1; //iffy - think it through

            if (largeStraightsExists && buttonIsEnabled)
                score = 40;

            return score;
        }

        public int Chance(bool buttonIsEnabled)
        {
            int score = 0;

            if (buttonIsEnabled)
                score = Sum();

            return score;
        }
    }
}