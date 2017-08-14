using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee.ViewModels
{
    public partial class MainViewModel
    {
        public virtual int Die1 { get; set; }
        public virtual int Die2 { get; set; }
        public virtual int Die3 { get; set; }
        public virtual int Die4 { get; set; }
        public virtual int Die5 { get; set; }

        public virtual bool AcesEnabled { get; set; }
        public virtual bool TwosEnabled { get; set; }
        public virtual bool ThreesEnabled { get; set; }
        public virtual bool FoursEnabled { get; set; }
        public virtual bool FivesEnabled { get; set; }
        public virtual bool SixesEnabled { get; set; }

        public virtual int AcesScore { get; set; }
        public virtual int TwosScore { get; set; }
        public virtual int ThreesScore { get; set; }
        public virtual int FoursScore { get; set; }
        public virtual int FivesScore { get; set; }
        public virtual int SixesScore { get; set; }

        public virtual bool ThreeOKindPointsEnabled { get; set; }
        public virtual bool FourOKindPointsEnabled { get; set; }
        public virtual bool FullHousePointsEnabled { get; set; }
        public virtual bool SmallStraightPointsEnabled { get; set; }
        public virtual bool LargeStraightPointsEnabled { get; set; }
        public virtual bool YahtzeePointsEnabled { get; set; }
        public virtual bool ChancePointsEnabled { get; set; }

        public virtual int ThreeOKindScore { get; set; }
        public virtual int FourOKindScore { get; set; }
        public virtual int FullHouseScore { get; set; }
        public virtual int SmallStraightScore { get; set; }
        public virtual int LargeStraightScore { get; set; }
        public virtual int YahtzeeScore { get; set; }
        public virtual int ChanceScore { get; set; }

        public virtual bool RollDiceButtonEnabled { get; set; }
        public virtual bool RollDiceAgainButtonEnabled { get; set; }
        public virtual bool TakeAnotherTurnButtonEnabled { get; set; }

        public virtual bool Hold1 { get; set; }
        public virtual bool Hold2 { get; set; }
        public virtual bool Hold3 { get; set; }
        public virtual bool Hold4 { get; set; }
        public virtual bool Hold5 { get; set; }

        public virtual int SectionOneSubtotalDisplay { get; set; }
        public virtual int SectionOneBonusDisplay { get; set; }
        public virtual int SectionTwoSubtotalDisplay { get; set; }
        public virtual int GrandTotalDisplay { get; set; }
    }
}
