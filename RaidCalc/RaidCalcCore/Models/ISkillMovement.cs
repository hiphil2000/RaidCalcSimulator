using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalcCore.Models
{
    public interface ISkillMovement : ISkillBase
    {
        int LimitMovement { get; set; }
    }
}
