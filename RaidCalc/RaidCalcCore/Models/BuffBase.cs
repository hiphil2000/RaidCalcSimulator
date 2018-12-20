using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class BuffBase
    {
        public IPlayer SourcePlayer { get; set; }
        public int Duration { get; set; }
        public int DurationRemains { get; set; }
        public double SkillConst { get; set; }
        public Func<Player, Player, bool> SkillFunction { get; set; }

        public BuffBase() { }

        public BuffBase(IPlayer src, int Duration, int DurationRemains, double SkillConst)
        {
            this.SourcePlayer = src as IPlayer;
            this.Duration = Duration;
            this.DurationRemains = DurationRemains;
            this.SkillConst = SkillConst;
        }
    }
}