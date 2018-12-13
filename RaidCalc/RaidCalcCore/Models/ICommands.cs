using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public interface ICommands
    {
        Player SourcePlayer { get; set; }
        Player DestinationPlayer { get; set; }
        object SkillObject { get; set; }
        ISkillBase UsedSkill { get; set; }
    }
}
