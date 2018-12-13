using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class Command : ICommands
    {
        public Player SourcePlayer { get; set; }
        public Player DestinationPlayer { get; set; }
        public object SkillObject { get; set; }
        public ISkillBase UsedSkill { get; set; }

        public Command() { }

        public Command(Player sourcePlayer, Player destinationPlayer, object skillObject, ISkillBase usedSkill) : this()
        {
            SourcePlayer = sourcePlayer;
            DestinationPlayer = destinationPlayer;
            SkillObject = skillObject;
            UsedSkill = usedSkill;
        }

        public void Execute()
        {
            UsedSkill.SkillFunction(SourcePlayer, DestinationPlayer, SkillObject);
        }
    }
}
