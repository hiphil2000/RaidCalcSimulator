using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalcCore.Models
{
    public struct Stats
    {
        public double Stat1;
        public double Stat2;
        public double Stat3;

        public Stats(double Stat1, double Stat2, double Stat3)
        {
            this.Stat1 = Stat1;
            this.Stat2 = Stat2;
            this.Stat3 = Stat3;
        }
    }
}
