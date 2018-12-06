using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalcCore.Models
{
    public interface IPlayer
    {
        string Name { get; set; }
        Stats Stat { get; set; }
        double MaxHp { get; set; }
        double CurrentHp { get; set; }
        double HarmConst { get; set; }  // 받는 피해 상수
        int PosX { get; set; }
        int PosY { get; set; }
        List<ISkillBase> CommonSkills { get; set; }    // 일반 고유 스킬
        ISkillBase UltimateSkill { get; set; }  // 궁극기
    }
}
