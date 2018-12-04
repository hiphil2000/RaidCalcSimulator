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

        public Perks Perk { get { return _Perk; } set { _Perk = value; } }
        private Perks _Perk; 

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

        public List<ISkillBase> UsedSkills;

        public Player() { }

        public Player(string name, Stats stat, Perks perk, double maxHp, double currentHp, double harmConst, int posX, int posY)
        {
            Name = name;
            Stat = stat;
            Perk = perk;
            MaxHp = maxHp;
            CurrentHp = currentHp;
            HarmConst = harmConst;
            PosX = posX;
            PosY = posY;
        }

        public Player(Player player) : this(player.Name, player.Stat, player.Perk, player.MaxHp, player.CurrentHp, player.HarmConst, player.PosX, player.PosY) { }

    }
}
