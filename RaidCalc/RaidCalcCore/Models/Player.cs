using System;
using System.Collections.Generic;
using System.Text;

namespace RaidCalcCore.Models
{
    public class Player : IPlayer
    {
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name; 

        public Stats Stat { get { return _Stat; } set { _Stat = value; } }
        private Stats _Stat; 

        public double MaxHp { get { return _MaxHp; } set { _MaxHp = value; } }
        private double _MaxHp; 

        public double CurrentHp { get { return _CurrentHp; } set { _CurrentHp = value; } }
        private double _CurrentHp; 

        public double HarmConst { get { return _HarmConst; } set { _HarmConst = value; } }
        private double _HarmConst; 

        public int PosX { get { return _PosX; } set { _PosX = value; } }
        private int _PosX; 

        public int PosY { get { return _PosY; } set { _PosY = value; } }
        private int _PosY; 

        public List<ISkillBase> CommonSkills { get { return _CommonSkills; } set { _CommonSkills = value; } }
        private List<ISkillBase> _CommonSkills;

        public ISkillBase UltimateSkill { get { return _UltimateSkill; } set { _UltimateSkill = value; } }

        public double GiveConst { get; set; }
        public double HealHarmConst { get; set; }
        public List<ISkillBase> Buffs { get; set; }

        private ISkillBase _UltimateSkill;

        public Player()
        {
            CommonSkills = new List<ISkillBase>();
        }

        public Player(string name, Stats stat, double maxHp, double currentHp, double harmConst, int posX, int posY) : this()
        {
            Name = name;
            Stat = stat;
            MaxHp = maxHp;
            CurrentHp = currentHp;
            HarmConst = harmConst;
            PosX = posX;
            PosY = posY;
        }

        public Player(Player player) : this(player.Name, player.Stat, player.MaxHp, player.CurrentHp, player.HarmConst, player.PosX, player.PosY) { }

        public void AddSkill(ISkillBase skill)
        {
            _CommonSkills.Add(skill);
        }

        public void AddSkillRange(List<ISkillBase> skills)
        {
            foreach(var s in skills)
            {
                _CommonSkills.Add(s);
            }
        }

        public void Copy(Player source)
        {
            Name = source.Name;
            Stat = source.Stat;
            MaxHp = source.MaxHp;
            CurrentHp = source.CurrentHp;
            HarmConst = source.HarmConst;
            PosX = source.PosX;
            PosY = source.PosY;
        }
    }
}
