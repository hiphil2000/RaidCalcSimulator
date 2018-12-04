using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Interfaces
{
    public interface IController
    {
        IView View { get; set; }
        RaidCalcWindow MainFrame { get; set; }
    }
}
