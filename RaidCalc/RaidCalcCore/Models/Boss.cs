using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class Boss : Player
    {
        private string type;
        private string[] description;
        private double mobHP;
        private string skillUpgradeKeyword;
        private List<BossSkillBase> skills;
        private List<TimeLine> timeLines;

        public Boss() { }

        public Boss(string name, string type, string[] description, double maxHP, double mobHP, string skillUpgradeKeyword, List<BossSkillBase> skills, List<TimeLine> timeLines) : this()
        {
            Name = name;
            this.type = type;
            this.description = description;
            MaxHp = maxHP;
            this.mobHP = mobHP;
            this.skillUpgradeKeyword = skillUpgradeKeyword;
            this.skills = skills;
            this.timeLines = timeLines;
        }
    }
}
