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
        public Func<IPlayer, IPlayer, object,  bool> SkillFunction { get; set; }
        public BuffType BuffType { get; set; }

        public BuffBase() { }

        public BuffBase(IPlayer src, BuffType BuffType, int Duration, int DurationRemains, double SkillConst)
        {
            this.SourcePlayer = src as IPlayer;
            this.BuffType = BuffType;
            this.Duration = Duration;
            this.DurationRemains = DurationRemains;
            this.SkillConst = SkillConst;
        }
        
        public void SetSkillFunction(Func<IPlayer, IPlayer, object, bool> function)
        {
            SkillFunction = function;
        }
    }
}