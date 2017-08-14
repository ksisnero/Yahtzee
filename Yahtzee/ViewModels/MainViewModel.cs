﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Yahtzee.Models;
using Yahtzee.Views;


namespace Yahtzee.ViewModels
{
    public partial class MainViewModel
    {
        private static List<int> _diceList;
        private static List<int> _sectionOnePointsList;
        private static List<int> _sectionTwoPointsList;

        private void _populateLists()
        {
            _diceList = new List<int> { Die1, Die2, Die3, Die4, Die5 };

            _sectionOnePointsList = new List<int> { AcesScore, TwosScore, ThreesScore, FoursScore, FivesScore, SixesScore };

            _sectionTwoPointsList = new List<int> { ThreeOKindScore, FourOKindScore, FullHouseScore, SmallStraightScore, LargeStraightScore, YahtzeeScore, ChanceScore };
        }

        public virtual void StartGame()
        {
            RollDiceButtonEnabled = true;

            Die1 = 0;
            Die2 = 0;
            Die3 = 0;
            Die4 = 0;
            Die5 = 0;
        }

        public virtual void Roll()
        {
            Die dieRandomizer = new Die();
            if(Hold1 == false)
                Die1 = dieRandomizer.Randomize();
            if(Hold2 == false)
                Die2 = dieRandomizer.Randomize();
            if(Hold3 == false)
                Die3 = dieRandomizer.Randomize();
            if(Hold4 == false)
                Die4 = dieRandomizer.Randomize();
            if(Hold5 == false)
                Die5 = dieRandomizer.Randomize();

            _populateLists();
            EnablePointButtons();
            PointSytem();
            DisableRollButtons();
            CheckIfGameOver();
        }

        public virtual void DisableRollButtons()
        {
            if (RollDiceButtonEnabled)
            {
                RollDiceButtonEnabled = false;
                RollDiceAgainButtonEnabled = true;
                TakeAnotherTurnButtonEnabled = false;
            }
            else if (RollDiceAgainButtonEnabled)
            {
                RollDiceButtonEnabled = false;
                RollDiceAgainButtonEnabled = false;
                TakeAnotherTurnButtonEnabled = true;
            }
            else if (TakeAnotherTurnButtonEnabled)
            {
                RollDiceButtonEnabled = true;
                RollDiceAgainButtonEnabled = false;
                TakeAnotherTurnButtonEnabled = false;
            }
        }

        public void EnablePointButtons()
        {
            AcesEnabled = true;
            TwosEnabled = true;
            ThreesEnabled = true;
            FoursEnabled = true;
            FivesEnabled = true;
            SixesEnabled = true;

            ThreeOKindPointsEnabled = true;
            FourOKindPointsEnabled = true;
            FullHousePointsEnabled = true;
            SmallStraightPointsEnabled = true;
            LargeStraightPointsEnabled = true;
            YahtzeePointsEnabled = true;
            ChancePointsEnabled = true;
        }

        public virtual void PointSytem()
        {
            ScoreCard scoringMethods = new ScoreCard(_diceList);

            if(AcesEnabled)
                AcesScore = scoringMethods.SumInstancesOfNumber(1, AcesEnabled);
            if(TwosEnabled)
                TwosScore = scoringMethods.SumInstancesOfNumber(2, TwosEnabled);
            if(ThreesEnabled)
                ThreesScore = scoringMethods.SumInstancesOfNumber(3, ThreesEnabled);
            if(FoursEnabled)
                FoursScore = scoringMethods.SumInstancesOfNumber(4, FoursEnabled);
            if(FivesEnabled)
                FivesScore = scoringMethods.SumInstancesOfNumber(5, FivesEnabled);
            if(SixesEnabled)
                SixesScore = scoringMethods.SumInstancesOfNumber(6, SixesEnabled);

            if(ThreeOKindPointsEnabled)
                ThreeOKindScore = scoringMethods.OfAKind(ThreeOKindPointsEnabled);
            if(FourOKindPointsEnabled)
                FourOKindScore = scoringMethods.OfAKind(FourOKindPointsEnabled);
            if(FullHousePointsEnabled)
                FullHouseScore = scoringMethods.FullHouse(FullHousePointsEnabled);
            if(SmallStraightPointsEnabled)
                SmallStraightScore = scoringMethods.SmallStraight(SmallStraightPointsEnabled);
            if(LargeStraightPointsEnabled)
                LargeStraightScore = scoringMethods.LargeStraight(LargeStraightPointsEnabled);
            if(YahtzeePointsEnabled)
                YahtzeeScore = scoringMethods.Yahtzee(YahtzeePointsEnabled);
            if (ChancePointsEnabled)
                ChanceScore = scoringMethods.Chance(ChancePointsEnabled);
        }

        public void Total()
        {
            SectionOneSubtotalDisplay = _sectionOnePointsList.Sum();
            SectionTwoSubtotalDisplay = _sectionTwoPointsList.Sum();

            if (SectionOneSubtotalDisplay > 62)
            {
                SectionOneBonusDisplay = 35;
                SectionOneSubtotalDisplay = SectionOneSubtotalDisplay + SectionOneBonusDisplay;
            }
        }

        public void CheckIfGameOver()
        {
            if (AcesEnabled == false
                && TwosEnabled == false
                && ThreesEnabled == false
                && FoursEnabled == false
                && FivesEnabled == false
                && SixesEnabled == false
                && ThreeOKindPointsEnabled == false
                && FourOKindPointsEnabled == false
                && FullHousePointsEnabled == false
                && SmallStraightPointsEnabled == false
                && LargeStraightPointsEnabled == false
                && YahtzeePointsEnabled == false
                && ChancePointsEnabled ==  false)
            {
                Total();
            }
        }

        #region WindowManipulation
        public virtual void About()
        {
            var x = new AboutWindow();
            x.ShowDialog();
        }

        public virtual void Exit()
        {
            var x = new MainWindow();
            x.Close();
        }

        public virtual void Help()
        {
            var x = new HelpWindow();
            x.ShowDialog();
        }
        #endregion
    }
}
