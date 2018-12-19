using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class BossSkillBase : ISkillBase
    {
        public string Name { get; set; }
        public double ForceConst { get; set; }
        public string SkillConst { get; set; }
        public SkillType Type { get; set; }
        public string RangeType { get; set; }
        public string RangeConst { get; set; }
        public string Description { get; set; }
        public string SkillScript { get; set; }
        public int Cooltime { get; set; }
        public int UsedTurn { get; set; }
        public Func<IPlayer, IPlayer, object, bool> SkillFunction { get; set; }

        public BossSkillBase() { }

        public BossSkillBase(string Name, string SkillConst, SkillType Type, string RangeType, string RangeConst, string Description, string SkillScript, int Cooltime) : this()
        {
            this.Name = Name;
            this.Type = Type;
            this.Cooltime = Cooltime;
            this.SkillConst = SkillConst;
            this.Description = Description;
            this.SkillScript = SkillScript;
        }
    }
}
