using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class Boss : Player
    {
        public string Type { get { return _type; } set { _type = value; } }
        private string _type;

        public string[] Description { get { return _description; } set { _description = value; } }
        private string[] _description;

        public double MobHp { get { return _mobHP; } set { _mobHP = value; } }
        private double _mobHP;

        public string SkillUpgradeKeyword { get { return _skillUpgradeKeyword; } set { _skillUpgradeKeyword = value; } }
        private string _skillUpgradeKeyword;

        public List<BossSkillBase> Skills { get { return _skills; } set { _skills = value; } }
        private List<BossSkillBase> _skills;

        public List<TimeLine> TimeLines { get { return _timeLines; } set { _timeLines = value; } }
        private List<TimeLine> _timeLines;

        public Boss() { }

        public Boss(string name, string type, string[] description, double maxHP, double mobHP, string skillUpgradeKeyword, List<BossSkillBase> skills, List<TimeLine> timeLines) : this()
        {
            Name = name;
            this._type = type;
            this._description = description;
            MaxHp = maxHP;
            this._mobHP = mobHP;
            this._skillUpgradeKeyword = skillUpgradeKeyword;
            this._skills = skills;
            this._timeLines = timeLines;
        }
    }
}
