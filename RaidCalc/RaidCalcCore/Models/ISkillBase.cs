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
        Perks Perk { get; set; }
        int Cooltime { get; set; }
        int Cost { get; set; }
    }
}
