using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidCalc.Interfaces
{
    public interface IView
    {
        IController Controller { get; set; }
        string ViewName { get; set; }

        void SetController(IController controller);
        void DrawData(object[] data);
    }
}
