using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalcCore.Models
{
    public interface ISkillBase
    {
        string Name { get; set; }
        SkillType Type { get; set; }
        int Cooltime { get; set; }
        int UsedTurn { get; set; }
        double ForceConst { get; set; }
        Func<IPlayer, IPlayer, object, bool> SkillFunction { get; set; }
        string Description { get; set; }
    }
}
