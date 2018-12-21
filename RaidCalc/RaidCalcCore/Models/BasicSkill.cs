using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class BasicSkill : ISkillBase
    {
        public string Name { get; set; }
        public SkillType Type { get; set; }
        public int Cooltime { get; set; }
        public int UsedTurn { get; set; }
        public double ForceConst { get; set; }
        public Func<IPlayer, IPlayer, object, bool> SkillFunction { get; set; }
        public void SetFunction(Func<IPlayer, IPlayer, object, bool> func)
        {
            SkillFunction = func;
        }
        public string Description { get; set; }
        public string RangeType { get; set; }
        public string RangeConst { get; set; }
    }
}
